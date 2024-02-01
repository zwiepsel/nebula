using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Nebula.Clients.FCB.Apps.Portal.Web.Data;
using Nebula.Clients.FCB.Apps.Portal.Web.Repositories;
using Nebula.Clients.FCB.Apps.Portal.Web.Settings;
using Nebula.Shared.Clients.Startup;

namespace Nebula.Clients.FCB.Apps.Portal.Web;

public class Startup : IAppStartup
{
    public void Configure(WebAssemblyHostBuilder webAssemblyHostBuilder)
    {
        webAssemblyHostBuilder.Services.AddAutoMapper(typeof(App));

        // Data services.
        webAssemblyHostBuilder.Services.AddScoped<AppApi, AppApi>();

        // Repository services.
        webAssemblyHostBuilder.Services.AddScoped<ClientRepository, ClientRepository>();
        webAssemblyHostBuilder.Services.AddScoped<ComplexRepository, ComplexRepository>();
        webAssemblyHostBuilder.Services.AddScoped<LeaseAgreementRepository, LeaseAgreementRepository>();
        webAssemblyHostBuilder.Services.AddScoped<HouseRepository, HouseRepository>();
        webAssemblyHostBuilder.Services.AddScoped<IncomeRepository, IncomeRepository>();
        webAssemblyHostBuilder.Services.AddScoped<NeighborhoodRepository, NeighborhoodRepository>();
        webAssemblyHostBuilder.Services.AddScoped<PersonRepository, PersonRepository>();
        webAssemblyHostBuilder.Services.AddScoped<RentRepository, RentRepository>();
        webAssemblyHostBuilder.Services.AddScoped<AgeScaleRepository, AgeScaleRepository>();
        webAssemblyHostBuilder.Services.AddScoped<FileRepository, FileRepository>();
        webAssemblyHostBuilder.Services.AddScoped<FileTypeRepository, FileTypeRepository>();
        webAssemblyHostBuilder.Services.AddScoped<IncomeScaleRepository, IncomeScaleRepository>();

        // Settings services.
        webAssemblyHostBuilder.Services.AddSingleton(new ApiSettings(webAssemblyHostBuilder.HostEnvironment.Environment));
    }
}