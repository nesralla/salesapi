namespace Ambev.DeveloperEvaluation.Application.SaleItens.CancelSaleItem
{
    /// <summary>
    /// Resultado do cancelamento de um item da venda
    /// </summary>
    public class CancelSaleItemResult
    {
        public Guid SaleId { get; set; }
        public decimal NewTotalAmount { get; set; }
        public bool IsItemCancelled { get; set; }
    }
}
