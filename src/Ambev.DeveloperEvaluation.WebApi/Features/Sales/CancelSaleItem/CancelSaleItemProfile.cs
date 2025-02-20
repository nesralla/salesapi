using AutoMapper;
using Ambev.DeveloperEvaluation.Application.SaleItens.CancelSaleItem;
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem
{


    /// <summary>
    /// Profile for mapping between Application and API CancelSaleItem responses
    /// </summary>
    public class CancelSaleItemProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CancelSaleItem feature
        /// </summary>
        public CancelSaleItemProfile()
        {
            CreateMap<CancelSaleItemRequest, CancelSaleItemCommand>();
            CreateMap<CancelSaleItemResult, CancelSaleItemResponse>();
        }
    }
}
