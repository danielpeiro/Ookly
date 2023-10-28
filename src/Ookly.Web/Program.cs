using Ookly.Core.AdAggregate;
using Ookly.Core.CountryAggregate;
using Ookly.Core.VehicleBrandAggregate;
using Ookly.Infrastructure.EntityFramework.Repositories;
using Ookly.UseCases.HomeUseCase;
using Ookly.UseCases.SearchUseCase;
using Ookly.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddElasticClient(builder.Configuration);

builder.Services.AddScoped<IAdRepository, AdRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IVehicleBrandRepository, VehicleBrandRepository>();

builder.Services.AddScoped<SeedTestDataService>();

builder.Services.AddScoped<HomeUseCaseHandler>();
builder.Services.AddScoped<SearchUseCaseHandler>();

builder.Services.AddScoped<IFacetService, FacetService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

if (app.Environment.IsDevelopment())
{
    app.SeedTestData();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();
