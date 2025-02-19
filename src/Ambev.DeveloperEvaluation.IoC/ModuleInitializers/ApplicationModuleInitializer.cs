using Ambev.DeveloperEvaluation.Application.SaleItens.CancelSaleItem;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Common.Security;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class ApplicationModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
        // Registrar todos os Handlers do MediatR
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateSaleHandler).Assembly));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateSaleHandler).Assembly));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CancelSaleHandler).Assembly));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CancelSaleItemHandler).Assembly));

        // Registrar todos os Validators
        builder.Services.AddValidatorsFromAssembly(typeof(CreateSaleValidator).Assembly);
        builder.Services.AddValidatorsFromAssembly(typeof(UpdateSaleValidator).Assembly);
        builder.Services.AddValidatorsFromAssembly(typeof(CancelSaleValidator).Assembly);
        builder.Services.AddValidatorsFromAssembly(typeof(CancelSaleItemCommandValidator).Assembly);
    }
}