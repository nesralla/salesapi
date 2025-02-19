namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{

    /// <summary>
    /// Representa a resposta ao cancelar uma venda
    /// </summary>
    public class CancelSaleResult
    {
        public Guid Id { get; set; }
        public bool IsCancelled { get; set; }
    }

}