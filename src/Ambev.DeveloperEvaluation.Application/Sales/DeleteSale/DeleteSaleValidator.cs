using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    /// <summary>
    /// Validador para DeleteSaleCommand
    /// </summary>
    public class DeleteSaleValidator : AbstractValidator<DeleteSaleCommand>
    {
        public DeleteSaleValidator()
        {
            RuleFor(x => x.SaleId)
                .NotEmpty().WithMessage("Sale ID is required");
        }
    }
}