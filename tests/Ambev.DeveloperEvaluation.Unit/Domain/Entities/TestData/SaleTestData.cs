using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    /// <summary>
    /// Geração de dados de teste  Sale
    /// </summary>
    public static class SaleTestData
    {
        private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
            .RuleFor(s => s.Id, f => Guid.NewGuid())
            .RuleFor(s => s.SaleNumber, f => f.Random.Guid().ToString())
            .RuleFor(s => s.SaleDate, f => f.Date.Past())
            .RuleFor(s => s.CustomerId, f => Guid.NewGuid())
            .RuleFor(s => s.BranchId, f => Guid.NewGuid())
            .RuleFor(s => s.Items, f => GenerateSaleItems());

        private static List<SaleItem> GenerateSaleItems()
        {
            return new List<SaleItem>
        {
            new SaleItem
            {
                Id = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Quantity = 5,
                UnitPrice = 100,
                Discount = 10
            }
        };
        }

        public static Sale GenerateValidSale()
        {
            return SaleFaker.Generate();
        }
    }

}