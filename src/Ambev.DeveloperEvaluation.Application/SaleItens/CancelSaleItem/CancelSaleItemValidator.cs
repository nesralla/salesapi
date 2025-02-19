using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItens.CancelSaleItem
{
    /// <summary>
    /// Validador para CancelSaleItemCommand
    /// </summary>
    public class CancelSaleItemCommandValidator : AbstractValidator<CancelSaleItemCommand>
    {
        public CancelSaleItemCommandValidator()
        {
            RuleFor(x => x.SaleId)
                .NotEmpty().WithMessage("Sale ID is required");

            RuleFor(x => x.ItemId)
                .NotEmpty().WithMessage("Item ID is required");

            RuleFor(x => x.QuantityToRemove)
                .GreaterThan(0).When(x => x.QuantityToRemove.HasValue)
                .WithMessage("Quantity to remove must be greater than zero");
        }
    }

}