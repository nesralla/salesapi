namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    using FluentValidation;

    namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
    {
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
}