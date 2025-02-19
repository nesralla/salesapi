using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    /// <summary>
    /// Command para deletar uma venda
    /// </summary>
    public class DeleteSaleCommand : IRequest<DeleteSaleResult>
    {
        public Guid SaleId { get; set; }
    }
}