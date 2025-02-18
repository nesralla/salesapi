using System.ComponentModel.DataAnnotations;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, SaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<SaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.ToString());

            // Aplicar regras de desconto
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

            var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);
            return _mapper.Map<SaleResult>(createdSale);
        }
    }

}