namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale
{
    /// <summary>
    /// Representa a requisição para cancelar uma venda
    /// </summary>
    public class CancelSaleRequest
    {
        public Guid SaleId { get; set; }
    }
}