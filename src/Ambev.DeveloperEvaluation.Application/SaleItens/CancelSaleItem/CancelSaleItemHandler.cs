using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.SaleItens.CancelSaleItem
{
    /// <summary>
    /// Handler para cancelar/remover um item de uma venda
    /// </summary>
    public class CancelSaleItemHandler : IRequestHandler<CancelSaleItemCommand, CancelSaleItemResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CancelSaleItemHandler> _logger;


        public CancelSaleItemHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<CancelSaleItemHandler> logger)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<CancelSaleItemResult> Handle(CancelSaleItemCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Processando solicitação para remover/cancelar item {ItemId} da venda {SaleId}", request.ItemId, request.SaleId);

            var sale = await _saleRepository.GetByIdAsync(request.SaleId, cancellationToken);
            if (sale == null)
                throw new KeyNotFoundException($"Sale with ID {request.SaleId} not found");

            var item = sale.Items.FirstOrDefault(i => i.Id == request.ItemId);
            if (item == null)
                throw new KeyNotFoundException($"Item with ID {request.ItemId} not found in sale");

            if (request.CancelItem)
            {
                item.IsCancelled = true;
                _logger.LogInformation("Item {ItemId} foi cancelado na venda {SaleId}", request.ItemId, request.SaleId);

            }
            else if (request.QuantityToRemove.HasValue)
            {
                if (request.QuantityToRemove.Value >= item.Quantity)
                {
                    sale.Items.Remove(item);
                    _logger.LogInformation("Item {ItemId} foi removido completamente da venda {SaleId}", request.ItemId, request.SaleId);

                }
                else
                {
                    item.Quantity -= request.QuantityToRemove.Value;
                    item.Discount = (item.Quantity >= 4 && item.Quantity < 10) ? item.UnitPrice * item.Quantity * 0.10m :
                                    (item.Quantity >= 10 && item.Quantity <= 20) ? item.UnitPrice * item.Quantity * 0.20m : 0;
                    _logger.LogInformation("Quantidade do item {ItemId} reduzida para {NewQuantity}. Novo desconto: {NewDiscount}",
                        request.ItemId, item.Quantity, item.Discount);
                }
            }

            await _saleRepository.UpdateAsync(sale, cancellationToken);
            _logger.LogInformation("Venda {SaleId} atualizada após remoção/cancelamento do item {ItemId}", request.SaleId, request.ItemId);

            return new CancelSaleItemResult
            {
                SaleId = sale.Id,
                NewTotalAmount = sale.Items.Sum(i => (i.UnitPrice * i.Quantity) - i.Discount),
                IsItemCancelled = item.IsCancelled
            };
        }
    }
}