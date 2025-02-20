using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{

    public class GetSaleProfile : Profile
    {
        public GetSaleProfile()
        {
            CreateMap<GetSaleCommand, Sale>();
            CreateMap<Sale, GetSaleResult>();
        }
    }
}