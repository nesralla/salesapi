namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// Representa a requisição para atualizar uma venda
    /// </summary>
    public class UpdateSaleRequest
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}