using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{

    /// <summary>
    /// Testes para a entidade Sale
    /// </summary>
    public class SaleTests
    {
        [Fact]
        public void Given_ValidSale_When_CalculatingTotalAmount_Then_ShouldBeCorrect()
        {
            // Arrange
            var sale = SaleTestData.GenerateValidSale();
            decimal expectedTotal = sale.Items.Sum(i => (i.UnitPrice * i.Quantity) - i.Discount);

            // Act
            var totalAmount = sale.TotalAmount;

            // Assert
            Assert.Equal(expectedTotal, totalAmount);
        }
    }

}