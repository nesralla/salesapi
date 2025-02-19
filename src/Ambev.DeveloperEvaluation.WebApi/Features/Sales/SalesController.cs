using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteUser;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItens.CancelSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// Controller for managing sales operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SalesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    private readonly ILogger<SalesController> _logger;

    /// <summary>
    /// Initializes a new instance of SalesController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// /// <param name="loggerr">The logger instance</param>
    public SalesController(IMediator mediator, IMapper mapper, ILogger<SalesController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Creates a new sales
    /// </summary>
    /// <param name="request">The sale creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Recebida solicitação para criar uma venda");
        var validator = new CreateSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validação falhou ao criar venda: {Errors}", validationResult.ToString());
            return BadRequest(validationResult.Errors);
        }
        var command = _mapper.Map<CreateSaleCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);
        _logger.LogInformation("Venda criada com sucesso");
        return Created(string.Empty, response);
    }

    /// <summary>
    /// Retrieves a sale by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetUserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetUserRequest { Id = id };
        var validator = new GetUserRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetUserCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetUserResponse>
        {
            Success = true,
            Message = "Sale retrieved successfully",
            Data = _mapper.Map<GetUserResponse>(response)
        });
    }

    /// <summary>
    /// Deletes a sales by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the user was deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSale(
        [FromRoute] Guid saleId,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Recebida solicitação para deletar a venda {SaleId}", saleId);

        var command = new DeleteSaleCommand { SaleId = saleId };
        var validator = new DeleteSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validação falhou para deletar a venda {SaleId}: {Errors}", saleId, validationResult.ToString());
            return BadRequest(validationResult.Errors);
        }

        var result = await _mediator.Send(command, cancellationToken);
        _logger.LogInformation("Venda {SaleId} deletada com sucesso", saleId);

        return Ok(result);
    }
    /// <summary>
    /// Cancel a sale
    /// </summary>
    [HttpPost("{id}/cancel")]
    public async Task<IActionResult> CancelSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Recebida solicitação para cancelar a venda {SaleId}", id);
        var command = new CancelSaleCommand { SaleId = id };
        var result = await _mediator.Send(command, cancellationToken);
        _logger.LogInformation("Venda {SaleId} cancelada com sucesso", id);
        return Ok(result);
    }

    /// <summary>
    /// Cancel and remove an item from a sale
    /// </summary>
    /// <param name="saleId">ID sale</param>
    /// <param name="itemId">ID sale item</param>
    /// <param name="request">Data of request </param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Sale Details  after</returns>
    [HttpPost("{saleId}/items/{itemId}/cancel")]
    public async Task<IActionResult> CancelSaleItem(
        [FromRoute] Guid saleId,
        [FromRoute] Guid itemId,
        [FromBody] CancelSaleItemRequest request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Recebida solicitação para cancelar/remover item {ItemId} da venda {SaleId}", itemId, saleId);
        var command = new CancelSaleItemCommand { SaleId = saleId, ItemId = itemId, QuantityToRemove = request.QuantityToRemove, CancelItem = request.CancelItem };
        var result = await _mediator.Send(command, cancellationToken);
        _logger.LogInformation("Item {ItemId} da venda {SaleId} processado com sucesso", itemId, saleId);
        return Ok(result);
    }

    /// <summary>
    /// Atualiza uma venda existente
    /// </summary>
    [HttpPut("{saleId}")]
    public async Task<IActionResult> UpdateSale(
        [FromRoute] Guid saleId,
        [FromBody] UpdateSaleRequest request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Recebida solicitação para atualizar a venda {SaleId}", saleId);

        if (saleId != request.SaleId)
        {
            _logger.LogWarning("O ID da venda na rota ({SaleId}) não corresponde ao ID no corpo da requisição ({RequestSaleId})", saleId, request.SaleId);
            return BadRequest("Mismatched Sale ID");
        }

        var validator = new UpdateSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validação falhou para a atualização da venda {SaleId}: {Errors}", saleId, validationResult.ToString());
            return BadRequest(validationResult.Errors);
        }

        var command = new UpdateSaleCommand
        {
            SaleId = request.SaleId,
            CustomerId = request.CustomerId,
            BranchId = request.BranchId,
            Items = request.Items
        };

        var result = await _mediator.Send(command, cancellationToken);
        _logger.LogInformation("Venda {SaleId} atualizada com sucesso", saleId);

        return Ok(result);
    }
}
