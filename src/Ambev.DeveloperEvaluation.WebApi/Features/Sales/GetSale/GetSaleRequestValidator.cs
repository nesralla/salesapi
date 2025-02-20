namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    using FluentValidation;

    /// <summary>
    /// Validador para CreateSaleRequest
    /// </summary>
    public class GetSaleRequestValidator : AbstractValidator<GetSaleRequest>
    {
        public GetSaleRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Sale ID is required");


        }
    }
}