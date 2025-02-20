
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Resultado da Venda
    /// </summary>
    public class CreateSaleResult
    {
        public Guid Id { get; set; }
        public string? SaleNumber { get; set; }
        public List<SaleItem> Items { get; init; } = new();
        public Guid CustomerId { get; init; }
        public Guid BranchId { get; init; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
    }
}
