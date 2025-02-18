using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{

    /// <summary>
    /// Validador para CreateSaleCommand
    /// </summary>
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {


        /// <summary>
        /// Initializes a new instance of the createslaecommand with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - customerid: Required
        /// - breanchid: Required
        /// - itens: At least one sale item is required
        /// </remarks>
        public CreateSaleValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required");

            RuleFor(x => x.BranchId)
                .NotEmpty().WithMessage("Branch ID is required");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("At least one sale item is required");
        }
    }
}