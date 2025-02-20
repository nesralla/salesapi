using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    /// <summary>
    /// Comando para buscar uma venda pelo ID
    /// </summary>
    public class GetSaleCommand : IRequest<GetSaleResult>
    {
        public Guid SaleId { get; set; }
    }
}