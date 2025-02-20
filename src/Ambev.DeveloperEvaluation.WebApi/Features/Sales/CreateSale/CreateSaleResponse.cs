using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Representa a resposta ao criar uma venda
    /// </summary>
    public class CreateSaleResponse
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = new();
        public Guid BranchId { get; set; }
        public Branch Branch { get; set; } = new();
        public List<SaleItem> Items { get; set; } = new List<SaleItem>();
    }
}
