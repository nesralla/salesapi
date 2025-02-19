using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    /// <summary>
    /// Handler para cancelar uma venda
    /// </summary>
    public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, CancelSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CancelSaleHandler> _logger;

        public CancelSaleHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<CancelSaleHandler> logger)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CancelSaleResult> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Recebida solicitação para cancelar a venda {SaleId}", request.SaleId);

            var sale = await _saleRepository.GetByIdAsync(request.SaleId, cancellationToken);
            if (sale == null)
            {
                _logger.LogWarning("Venda {SaleId} não encontrada", request.SaleId);
                throw new KeyNotFoundException($"Sale with ID {request.SaleId} not found");
            }

            if (sale.IsCancelled)
            {
                _logger.LogWarning("Venda {SaleId} já está cancelada", request.SaleId);
                throw new InvalidOperationException("Sale is already cancelled");
            }

            sale.IsCancelled = true;
            await _saleRepository.UpdateAsync(sale, cancellationToken);

            _logger.LogInformation("Venda {SaleId} cancelada com sucesso", request.SaleId);
            return _mapper.Map<CancelSaleResult>(sale);
        }
    }

}