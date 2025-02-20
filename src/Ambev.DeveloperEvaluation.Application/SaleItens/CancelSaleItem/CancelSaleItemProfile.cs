using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SaleItens.CancelSaleItem
{


    public class CancelSaleItemProfile : Profile
    {
        public CancelSaleItemProfile()
        {
            CreateMap<CancelSaleItemCommand, SaleItem>();
            CreateMap<SaleItem, CancelSaleItemResult>();
        }
    }
}