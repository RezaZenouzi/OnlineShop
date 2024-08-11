var builder = WebApplication.CreateBuilder(args);

#region Services to Continer

// Add services to the container.
builder.Services.AddRazorPages();

#endregion

var app = builder.Build();

#region Configuration of HTTP Request Pipeline

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

#endregion

app.Run();