namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class CancelSaleItemEvent
    {
        public Guid SaleItemId { get; set; }
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
    }
}