using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    /// <summary>
    /// Handler para deletar uma venda
    /// </summary>
    public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ILogger<DeleteSaleHandler> _logger;

        public DeleteSaleHandler(ISaleRepository saleRepository, ILogger<DeleteSaleHandler> logger)
        {
            _saleRepository = saleRepository;
            _logger = logger;
        }

        public async Task<DeleteSaleResult> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Processando exclusão da venda {SaleId}", request.SaleId);

            var sale = await _saleRepository.GetByIdAsync(request.SaleId, cancellationToken);
            if (sale == null)
            {
                _logger.LogWarning("Venda {SaleId} não encontrada", request.SaleId);
                return new DeleteSaleResult { Success = false, Message = "Sale not found" };
            }

            await _saleRepository.DeleteAsync(sale.Id, cancellationToken);
            _logger.LogInformation("Venda {SaleId} excluída com sucesso", request.SaleId);

            return new DeleteSaleResult { Success = true, Message = "Sale deleted successfully" };
        }
    }
}
