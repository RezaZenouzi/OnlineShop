using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

#region Services to Continer

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
builder.Services.AddRateLimiter(rateLimitedOptions =>
{
    rateLimitedOptions.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(10);
        options.PermitLimit = 5;
    });
});

#endregion

var app = builder.Build();

#region Configuration of HTTP Request Pipeline

app.UseRateLimiter();
app.MapReverseProxy();

#endregion

app.Run();
