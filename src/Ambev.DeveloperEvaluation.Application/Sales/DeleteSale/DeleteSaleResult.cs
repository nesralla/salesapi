namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    /// <summary>
    /// Resposta da exclusão de venda
    /// </summary>
    public class DeleteSaleResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
