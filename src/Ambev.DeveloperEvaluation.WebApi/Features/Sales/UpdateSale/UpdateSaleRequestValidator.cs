using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// Validador para CreateSaleRequest
    /// </summary>
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        public UpdateSaleRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Sale ID is required");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product ID is required");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity is required")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required")
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}