using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Validador para CreateSaleRequest
    /// </summary>
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required");

            RuleFor(x => x.BranchId)
                .NotEmpty().WithMessage("Branch ID is required");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("At least one sale item is required");

            RuleForEach(x => x.Items)
                .Must(i => i.Quantity <= 20)
                .WithMessage("Cannot sell more than 20 identical items");
        }
    }
}