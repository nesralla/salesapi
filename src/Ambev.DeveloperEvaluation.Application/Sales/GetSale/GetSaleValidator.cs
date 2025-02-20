using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    /// <summary>
    /// Validador para buscar uma venda
    /// </summary>
    public class GetSaleValidator : AbstractValidator<GetSaleCommand>
    {
        public GetSaleValidator()
        {
            RuleFor(x => x.SaleId)
                .NotEmpty().WithMessage("O ID da venda é obrigatório.")
                .NotEqual(Guid.Empty).WithMessage("O ID da venda não pode ser vazio.");
        }
    }
}