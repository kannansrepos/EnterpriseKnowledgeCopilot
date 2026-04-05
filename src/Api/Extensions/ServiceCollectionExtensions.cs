using Application;
using Infrastructure;
using Microsoft.OpenApi;

namespace Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwagger();
        services.AddApiInternalServices(configuration);
        return services;
    }

    private static IServiceCollection AddApiInternalServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationServices(configuration);
        services.AddInfrastructureServices(configuration);
        return services;
    }

    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddOpenApi();
        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Enterprise AI Decision Platform API",
                Version = "v1",
                Description = "Foundation API for enterprise AI decision intelligence platform"
            });
        });

        return services;
    }
}