using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    /// <summary>
    /// Geração de dados de teste para a entidade Sale e CancelSaleHandlerTests
    /// </summary>
    public static class CancelSaleHandlerTestData
    {
        public static CancelSaleCommand GetValidCancelSaleCommand()
        {
            return new CancelSaleCommand { SaleId = Guid.NewGuid() };
        }

        public static CancelSaleCommand GetInvalidCancelSaleCommand()
        {
            return new CancelSaleCommand { SaleId = Guid.Empty };
        }

        public static Sale GetSaleForCancellation()
        {
            return new Sale
            {
                Id = Guid.NewGuid(),
                SaleNumber = Guid.NewGuid().ToString(),
                CustomerId = Guid.NewGuid(),
                BranchId = Guid.NewGuid(),
                Items = new List<SaleItem>(),
                IsCancelled = false
            };
        }
    }
}