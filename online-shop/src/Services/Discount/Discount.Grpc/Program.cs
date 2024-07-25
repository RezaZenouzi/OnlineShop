
var builder = WebApplication.CreateBuilder(args);

#region Services to Continer

builder.Services.AddGrpc();

#endregion

var app = builder.Build();

#region Configuration of HTTP Request Pipeline

//app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

#endregion

app.Run();
