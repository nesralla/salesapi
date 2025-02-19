using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{

    /// <summary>
    /// Validador para UpdateSaleCommand
    /// </summary>
    public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
    {
        public UpdateSaleValidator()
        {
            RuleFor(x => x.SaleId)
                .NotEmpty().WithMessage("Sale ID is required");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required");

            RuleFor(x => x.BranchId)
                .NotEmpty().WithMessage("Branch ID is required");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("At least one sale item is required");
        }
    }
}