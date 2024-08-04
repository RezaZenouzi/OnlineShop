using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

#region Services to Continer

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddOrderingApiServices(builder.Configuration);

#endregion

var app = builder.Build();

#region Configuration of HTTP Request Pipeline

app.UseApiServices();
if (app.Environment.IsDevelopment())
    await app.InitializeDatabaseAsync();

#endregion

app.Run();
