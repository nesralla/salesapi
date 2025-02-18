using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    /// <summary>
    /// Representa a requisição para cancelar uma venda
    /// </summary>
    public class CancelSaleCommand : IRequest<CancelSaleResponse>
    {
        public Guid SaleId { get; set; }
    }

}