using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{/// <summary>
 /// Command para criar uma venda
 /// </summary>
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        public List<SaleItem> Items { get; init; }
        public Guid CustomerId { get; init; }
        public Guid BranchId { get; init; }

        public CreateSaleCommand(List<SaleItem> items, Guid customerId, Guid branchId)
        {
            Items = items;
            CustomerId = customerId;
            BranchId = branchId;
        }
    }




}