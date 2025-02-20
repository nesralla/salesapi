using Ambev.DeveloperEvaluation.Application;
using Ambev.DeveloperEvaluation.Application.SaleItens.CancelSaleItem;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Repositories;
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
        // Registrar todos os Handlers do MediatR
        builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(ApplicationLayer).Assembly)
        );


        builder.Services.AddValidatorsFromAssembly(typeof(ApplicationLayer).Assembly);

        builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ISaleRepository, SaleRepository>();
        builder.Services.AddScoped<ISaleItemRepository, SaleItemRepository>();
        builder.Services.AddScoped<IBranchRepository, BranchRepository>();
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();


        // Registrar todos os Validators
        // builder.Services.AddValidatorsFromAssembly(typeof(CreateSaleValidator).Assembly);
        // builder.Services.AddValidatorsFromAssembly(typeof(UpdateSaleValidator).Assembly);
        // builder.Services.AddValidatorsFromAssembly(typeof(CancelSaleValidator).Assembly);
        // builder.Services.AddValidatorsFromAssembly(typeof(CancelSaleItemCommandValidator).Assembly);
    }
}