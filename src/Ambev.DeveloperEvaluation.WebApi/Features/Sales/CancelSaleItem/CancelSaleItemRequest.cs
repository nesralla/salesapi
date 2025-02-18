namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem
{

    /// <summary>
    /// Representa a requisição para cancelar/remover um item de uma venda
    /// </summary>
    public class CancelSaleItemRequest
    {
        public int? QuantityToRemove { get; set; }
        public bool CancelItem { get; set; }
    }
}