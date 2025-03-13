using Application.Injections;
using Application.Settings;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var backendConfiguration = builder.Configuration.GetSection("BackendConfiguration").Get<BackendConfiguration>();
builder.Services.AddSingleton(backendConfiguration);

Injector.DependenceInjection(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
