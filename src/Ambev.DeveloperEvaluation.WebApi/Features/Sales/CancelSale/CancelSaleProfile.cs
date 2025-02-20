using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

/// <summary>
/// Profile for mapping between Application and API CreateUser responses
/// </summary>
public class CancelSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser feature
    /// </summary>
    public CancelSaleProfile()
    {
        CreateMap<CancelSaleRequest, CancelSaleCommand>();
        CreateMap<CancelSaleResult, CancelSaleResponse>();
    }
}
