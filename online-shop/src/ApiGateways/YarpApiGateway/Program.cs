var builder = WebApplication.CreateBuilder(args);

#region Services to Continer

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

#endregion

var app = builder.Build();

#region Configuration of HTTP Request Pipeline

app.MapReverseProxy();

#endregion

app.Run();
