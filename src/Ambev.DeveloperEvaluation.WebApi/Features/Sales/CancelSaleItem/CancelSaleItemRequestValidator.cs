using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem
{
    /// <summary>
    /// Validador para CancelSaleItemRequest
    /// </summary>
    public class CancelSaleItemRequestValidator : AbstractValidator<CancelSaleItemRequest>
    {
        public CancelSaleItemRequestValidator()
        {
            RuleFor(x => x.QuantityToRemove)
                .GreaterThan(0).When(x => x.QuantityToRemove.HasValue)
                .WithMessage("Quantity to remove must be greater than zero");
        }
    }

}