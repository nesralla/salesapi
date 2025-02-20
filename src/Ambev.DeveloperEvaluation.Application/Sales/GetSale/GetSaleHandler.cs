using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    /// <summary>
    /// Handler para buscar uma venda pelo ID
    /// </summary>
    public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        private readonly ILogger<GetSaleHandler> _logger;

        public GetSaleHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<GetSaleHandler> logger)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<GetSaleResult> Handle(GetSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetSaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }

            var sale = await _saleRepository.GetByIdAsync(request.SaleId, cancellationToken);
            if (sale == null)
            {
                throw new KeyNotFoundException($"Venda com ID {request.SaleId} não encontrada.");
            }

            return _mapper.Map<GetSaleResult>(sale);
        }
    }
}