namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem
{
    /// <summary>
    /// Representa a resposta ao cancelar/remover um item de uma venda
    /// </summary>
    public class CancelSaleItemResponse
    {
        public Guid SaleId { get; set; }
        public decimal NewTotalAmount { get; set; }
        public bool IsItemCancelled { get; set; }
    }
}