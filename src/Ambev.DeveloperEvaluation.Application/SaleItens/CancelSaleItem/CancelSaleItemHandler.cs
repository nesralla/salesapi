using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItens.CancelSaleItem
{
    /// <summary>
    /// Handler para cancelar/remover um item de uma venda
    /// </summary>
    public class CancelSaleItemHandler : IRequestHandler<CancelSaleItemCommand, CancelSaleItemResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public CancelSaleItemHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<CancelSaleItemResult> Handle(CancelSaleItemCommand request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetByIdAsync(request.SaleId, cancellationToken);
            if (sale == null)
                throw new KeyNotFoundException($"Sale with ID {request.SaleId} not found");

            var item = sale.Items.FirstOrDefault(i => i.Id == request.ItemId);
            if (item == null)
                throw new KeyNotFoundException($"Item with ID {request.ItemId} not found in sale");

            if (request.CancelItem)
            {
                item.IsCancelled = true;
            }
            else if (request.QuantityToRemove.HasValue)
            {
                if (request.QuantityToRemove.Value >= item.Quantity)
                {
                    sale.Items.Remove(item);
                }
                else
                {
                    item.Quantity -= request.QuantityToRemove.Value;
                    item.Discount = (item.Quantity >= 4 && item.Quantity < 10) ? item.UnitPrice * item.Quantity * 0.10m :
                                    (item.Quantity >= 10 && item.Quantity <= 20) ? item.UnitPrice * item.Quantity * 0.20m : 0;
                }
            }

            await _saleRepository.UpdateAsync(sale, cancellationToken);

            return new CancelSaleItemResult
            {
                SaleId = sale.Id,
                NewTotalAmount = sale.Items.Sum(i => (i.UnitPrice * i.Quantity) - i.Discount),
                IsItemCancelled = item.IsCancelled
            };
        }
    }
}