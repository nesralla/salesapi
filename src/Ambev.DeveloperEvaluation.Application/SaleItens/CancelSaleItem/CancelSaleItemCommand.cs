using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItens.CancelSaleItem
{

    /// <summary>
    /// Command para cancelar/remover um item de uma venda
    /// </summary>
    public class CancelSaleItemCommand : IRequest<CancelSaleItemResult>
    {
        public Guid SaleId { get; set; }
        public Guid ItemId { get; set; }
        public int? QuantityToRemove { get; set; }
        public bool CancelItem { get; set; }
    }
}