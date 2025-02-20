namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class UpdateSaleEvent
    {
        public Guid SaleId { get; set; }
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
    }
}