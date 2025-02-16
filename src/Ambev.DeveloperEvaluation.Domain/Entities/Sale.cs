using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public Sale()
        {
            Id = Guid.NewGuid();
            Customer = new Customer();
            Branch = new Branch();
            SaleNumber = string.Empty;
        }

        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid BranchId { get; set; }
        public Branch Branch { get; set; }
        public List<SaleItem> Items { get; set; } = new List<SaleItem>();
        public decimal TotalAmount => Items.Sum(item => item.TotalItemAmount);
        public bool IsCancelled { get; set; }

    }
}
