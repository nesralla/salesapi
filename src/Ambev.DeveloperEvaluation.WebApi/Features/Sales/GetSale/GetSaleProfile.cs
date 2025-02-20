using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    /// <summary>
    /// Profile for mapping between Application and API CreateSale responses
    /// </summary>
    public class GetSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateSale feature
        /// </summary>
        public GetSaleProfile()
        {
            CreateMap<GetSaleRequest, GetSaleCommand>();
            CreateMap<GetSaleResult, GetSaleResponse>();
        }
    }
}