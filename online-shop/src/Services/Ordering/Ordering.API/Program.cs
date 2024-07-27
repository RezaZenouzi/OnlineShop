using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

#region Services to Continer

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddOrderingApiServices();

#endregion

var app = builder.Build();

#region Configuration of HTTP Request Pipeline



#endregion

app.Run();
