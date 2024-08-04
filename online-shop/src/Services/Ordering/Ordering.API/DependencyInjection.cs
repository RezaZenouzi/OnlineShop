﻿using BuildingBlocks.Exceptions.Handler;
using Carter;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddOrderingApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddHealthChecks().AddSqlServer(configuration.GetConnectionString("Database")!);
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.MapCarter();
        app.UseExceptionHandler(options => { });
        app.UseHealthChecks("/health", new HealthCheckOptions()
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        return app;
    }
}