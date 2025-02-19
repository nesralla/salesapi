namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale
{
    /// <summary>
    /// Representa a resposta ao deletar uma venda
    /// </summary>
    public class DeleteSaleResponse
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
