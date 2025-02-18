using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Representa a requisição para criar uma venda
    /// </summary>
    public class CreateSaleRequest
    {
        public List<SaleItem> Items { get; set; } = new();
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
    }

}