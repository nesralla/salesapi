namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// Representa a resposta para atualizar uma venda
    /// </summary>
    public class UpdateSaleResponse
    {
        public Guid Id { get; set; }
        public bool Success { get; set; }
    }
}