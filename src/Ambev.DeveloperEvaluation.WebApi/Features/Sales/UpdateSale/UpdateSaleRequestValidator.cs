using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{

    /// <summary>
    /// Validador para UpdateSaleRequest
    /// </summary>
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        public UpdateSaleRequestValidator()
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