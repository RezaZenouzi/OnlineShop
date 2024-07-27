namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddOrderingApiServices(this IServiceCollection services)
    {
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        return app;
    }
}