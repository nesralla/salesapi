using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    /// <summary>
    /// Geração de dados de teste para CreateSaleHandlerTests
    /// </summary>
    public static class CreateSaleHandlerTestData
    {
        public static CreateSaleCommand GetValidCreateSaleCommand()
        {
            var faker = new Faker();
            return new CreateSaleCommand(
                new List<SaleItem>
                {
                    new() { ProductId = Guid.NewGuid(), Quantity = 5, UnitPrice = 100 }
                },
                Guid.NewGuid(),
                Guid.NewGuid()
            );
        }

        public static CreateSaleCommand GetInvalidCreateSaleCommand()
        {
            return new CreateSaleCommand(
                new List<SaleItem>(),
                Guid.Empty,
                Guid.Empty
            );
        }

        public static Sale GetSaleFromCommand(CreateSaleCommand command)
        {
            return new Sale
            {
                Id = Guid.NewGuid(),
                SaleNumber = Guid.NewGuid().ToString(),
                CustomerId = command.CustomerId,
                BranchId = command.BranchId,
                Items = new List<SaleItem>()
            };
        }
    }
}