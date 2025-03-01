namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale
{

    /// <summary>
    /// Representa a resposta ao cancelar uma venda
    /// </summary>
    public class CancelSaleResponse
    {
        public Guid Id { get; set; }
        public bool IsCancelled { get; set; }
    }
}