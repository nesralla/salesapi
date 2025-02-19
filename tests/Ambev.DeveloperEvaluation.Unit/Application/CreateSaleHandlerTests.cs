using System.ComponentModel.DataAnnotations;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    /// <summary>
    /// Testes para a criação de vendas
    /// </summary>
    public class CreateSaleHandlerTests
    {
        private readonly Mock<ISaleRepository> _saleRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<CreateSaleHandler>> _loggerMock;
        private readonly CreateSaleHandler _handler;

        public CreateSaleHandlerTests()
        {
            _saleRepositoryMock = new Mock<ISaleRepository>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<CreateSaleHandler>>();
            _handler = new CreateSaleHandler(_saleRepositoryMock.Object, _mapperMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ShouldCreateSaleSuccessfully()
        {
            // Arrange
            var request = CreateSaleHandlerTestData.GetValidCreateSaleCommand();
            var sale = CreateSaleHandlerTestData.GetSaleFromCommand(request);

            _saleRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<Sale>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(sale);
            _mapperMock.Setup(mapper => mapper.Map<SaleResult>(It.IsAny<Sale>()))
                .Returns(new SaleResult { Id = sale.Id, SaleNumber = sale.SaleNumber });

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(sale.Id);
            _saleRepositoryMock.Verify(repo => repo.CreateAsync(It.IsAny<Sale>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidRequest_ShouldThrowValidationException()
        {
            // Arrange
            var request = CreateSaleHandlerTestData.GetInvalidCreateSaleCommand();

            // Act
            Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<ValidationException>();
        }
    }
}