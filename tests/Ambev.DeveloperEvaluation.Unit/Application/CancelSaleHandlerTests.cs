using System.ComponentModel.DataAnnotations;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    /// <summary>
    /// Testes para o cancelamento de vendas
    /// </summary>
    public class CancelSaleHandlerTests
    {
        private readonly Mock<ISaleRepository> _saleRepositoryMock;
        private readonly Mock<ILogger<CancelSaleHandler>> _loggerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CancelSaleHandler _handler;

        public CancelSaleHandlerTests()
        {
            _saleRepositoryMock = new Mock<ISaleRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new CancelSaleHandler(_saleRepositoryMock.Object, _mapperMock.Object, _loggerMock.Object);

        }

        [Fact]
        public async Task Handle_ValidRequest_ShouldCancelSaleSuccessfully()
        {
            // Arrange
            var request = CancelSaleHandlerTestData.GetValidCancelSaleCommand();
            var sale = CancelSaleHandlerTestData.GetSaleForCancellation();
            _saleRepositoryMock.Setup(repo => repo.GetByIdAsync(request.SaleId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(sale);
            _saleRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Sale>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(sale));

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(sale.Id);
            result.IsCancelled.Should().BeTrue();
            _saleRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Sale>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidRequest_ShouldThrowValidationException()
        {
            // Arrange
            var request = CancelSaleHandlerTestData.GetInvalidCancelSaleCommand();

            // Act
            Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<ValidationException>();
        }
    }
}