using Microsoft.EntityFrameworkCore;
using ModernisationChallenge.DAL;
using ModernisationChallenge.DAL.Services;
using ModernisationChallenge.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();

// Add services to the container.
var services = builder.Services;
services.AddControllersWithViews();

services.AddDbContext<ModerniseDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ModerniseConnection")));

BaseServices.RegisterServices(services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseMiddleware<HttpExceptionLoggingMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
