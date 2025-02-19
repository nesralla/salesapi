namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale
{
    /// <summary>
    /// Representa a requisição para delete uma venda
    /// </summary>
    public class DeleteSaleRequest
    {
        public Guid SaleId { get; set; }

    }
}