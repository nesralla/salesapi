using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public SaleItem()
        {
            Id = Guid.NewGuid();
            Sale = new Sale();
            Product = new Product();
        }
        public Guid SaleId { get; set; }
        public Sale Sale { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalItemAmount => (UnitPrice * Quantity) - Discount;
        public bool IsCancelled { get; set; }
    }
}
