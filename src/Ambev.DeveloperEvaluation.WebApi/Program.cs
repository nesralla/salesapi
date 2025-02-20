using Ambev.DeveloperEvaluation.Application;
using Ambev.DeveloperEvaluation.Common.HealthChecks;
using Ambev.DeveloperEvaluation.Common.Logging;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.IoC;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.WebApi.Middleware;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Ambev.DeveloperEvaluation.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {


            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            // Configuração do Serilog
            builder.Host.UseSerilog((ctx, lc) => lc
                .WriteTo.Console()
                .ReadFrom.Configuration(ctx.Configuration));

            // Configurações do IoC (Injeção de Dependências)


            builder.AddDefaultLogging();
            builder.AddBasicHealthChecks();

            builder.RegisterDependencies();
            builder.Services.AddControllers();


            builder.Services.AddEndpointsApiExplorer();


            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DefaultContext>(options =>
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
                )
            );

            /// builder.Services.AddJwtAuthentication(builder.Configuration);



            builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ApplicationLayer).Assembly);



            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            var app = builder.Build();
            app.UseMiddleware<ValidationExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                                {
                                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ambev Developer Evaluation API v1");
                                    c.RoutePrefix = "api-docs";
                                });
            }

            app.UseHttpsRedirection();
            // app.UseAuthentication();
            // app.UseAuthorization();
            app.MapControllers();

            Log.Information("Starting web application");

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
