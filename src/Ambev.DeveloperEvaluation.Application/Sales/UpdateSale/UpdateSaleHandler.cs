using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{

    /// <summary>
    /// Handler para atualizar uma venda
    /// </summary>
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateSaleHandler> _logger;

        public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<UpdateSaleHandler> logger)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Recebida solicitação para atualizar a venda {SaleId}", request.SaleId);

            var sale = await _saleRepository.GetByIdAsync(request.SaleId, cancellationToken);
            if (sale == null)
            {
                _logger.LogWarning("Venda {SaleId} não encontrada", request.SaleId);
                throw new KeyNotFoundException($"Sale with ID {request.SaleId} not found");
            }

            if (sale.IsCancelled)
            {
                _logger.LogWarning("Venda {SaleId} já foi cancelada e não pode ser alterada", request.SaleId);
                throw new InvalidOperationException("A cancelled sale cannot be modified");
            }

            sale.CustomerId = request.CustomerId;
            sale.BranchId = request.BranchId;
            sale.Items = request.Items;

            _logger.LogInformation("Aplicando regras de desconto para os itens da venda {SaleId}", request.SaleId);
            foreach (var item in sale.Items)
            {
                if (item.Quantity >= 4 && item.Quantity < 10)
                    item.Discount = item.UnitPrice * item.Quantity * 0.10m;
                else if (item.Quantity >= 10 && item.Quantity <= 20)
                    item.Discount = item.UnitPrice * item.Quantity * 0.20m;
                else
                    item.Discount = 0;
            }

            await _saleRepository.UpdateAsync(sale, cancellationToken);
            _logger.LogInformation("Venda {SaleId} atualizada com sucesso", request.SaleId);

            return _mapper.Map<UpdateSaleResult>(sale);
        }
    }
}