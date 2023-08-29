using calculo_cdb.Application.Interfaces;
using calculo_cdb.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace calculo_cdb.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICalcularRetornoCDB, CalcularRetornoCDB>();

        return services;
    }
}