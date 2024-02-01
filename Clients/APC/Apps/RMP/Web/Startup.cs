using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Nebula.Clients.APC.Apps.RMP.Web.Data;
using Nebula.Clients.APC.Apps.RMP.Web.Repositories;
using Nebula.Clients.APC.Apps.RMP.Web.Settings;
using Nebula.Shared.Clients.Startup;

namespace Nebula.Clients.APC.Apps.RMP.Web;

public class Startup : IAppStartup
{
    public void Configure(WebAssemblyHostBuilder webAssemblyHostBuilder)
    {
        webAssemblyHostBuilder.Services.AddAutoMapper(typeof(App));

        // Data services.
        webAssemblyHostBuilder.Services.AddScoped<AppApi, AppApi>();

        // Repository services.
        webAssemblyHostBuilder.Services.AddScoped<CosoRepository, CosoRepository>();
        webAssemblyHostBuilder.Services.AddScoped<DepartmentRepository, DepartmentRepository>();
        webAssemblyHostBuilder.Services.AddScoped<FileRepository, FileRepository>();
        webAssemblyHostBuilder.Services.AddScoped<FileTypeRepository, FileTypeRepository>();
        webAssemblyHostBuilder.Services.AddScoped<FirmRepository, FirmRepository>();
        webAssemblyHostBuilder.Services.AddScoped<MitigationControlRepository, MitigationControlRepository>();
        webAssemblyHostBuilder.Services.AddScoped<ProcessRepository, ProcessRepository>();
        webAssemblyHostBuilder.Services.AddScoped<RiskRepository, RiskRepository>();
        webAssemblyHostBuilder.Services.AddScoped<RiskScoreRepository, RiskScoreRepository>();

        // Settings services.
        webAssemblyHostBuilder.Services.AddSingleton(new ApiSettings(webAssemblyHostBuilder.HostEnvironment.Environment));
    }
}