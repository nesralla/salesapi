using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// Representa a requisição para atualizar uma venda
    /// </summary>
    public class UpdateSaleRequest
    {
        public Guid SaleId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public List<SaleItem> Items { get; set; } = new();
    }

}