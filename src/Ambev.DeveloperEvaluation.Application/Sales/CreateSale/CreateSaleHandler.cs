using System.ComponentModel.DataAnnotations;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, SaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateSaleHandler> _logger;


        public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<CreateSaleHandler> logger)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<SaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Recebida solicitação para criar uma nova venda");

            var validator = new CreateSaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validação falhou para a criação da venda: {ValidationErrors}", validationResult.ToString());

                throw new ValidationException(validationResult.ToString());
            }


            _logger.LogInformation("Aplicando regras de desconto para os itens da venda");

            foreach (var item in request.Items)
            {
                if (item.Quantity >= 4 && item.Quantity < 10)
                    item.Discount = item.UnitPrice * item.Quantity * 0.10m; // 10% de desconto
                else if (item.Quantity >= 10 && item.Quantity <= 20)
                    item.Discount = item.UnitPrice * item.Quantity * 0.20m; // 20% de desconto
                else
                    item.Discount = 0; // Sem desconto para menos de 4 ou mais de 20 itens
            }

            var sale = new Sale
            {
                SaleNumber = Guid.NewGuid().ToString(),
                SaleDate = DateTime.UtcNow,
                CustomerId = request.CustomerId,
                BranchId = request.BranchId,
                Items = request.Items,
                IsCancelled = false
            };
            _logger.LogInformation("Criando venda no banco de dados");
            var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);
            _logger.LogInformation("Venda {SaleNumber} criada com sucesso", createdSale.SaleNumber);

            return _mapper.Map<SaleResult>(createdSale);
        }
    }

}