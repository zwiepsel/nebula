using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Nebula.Clients.FCB.Shared.Models.OnboardingState;
using Nebula.Clients.FCB.Sites.MyFCB.Data;
using Nebula.Clients.FCB.Sites.MyFCB.Repositories;
using Nebula.Clients.FCB.Sites.MyFCB.Settings;
using Nebula.Shared.Clients.Startup;

namespace Nebula.Clients.FCB.Sites.MyFCB;

public class Startup : ISiteStartup
{
    public void Configure(WebAssemblyHostBuilder webAssemblyHostBuilder)
    {
        webAssemblyHostBuilder.Services.AddAutoMapper(typeof(Site));
        // Data services.
        webAssemblyHostBuilder.Services.AddScoped<AppApi, AppApi>();
        webAssemblyHostBuilder.Services.AddSingleton<OnBoardingState, OnBoardingState>();
        // Repository services.
        webAssemblyHostBuilder.Services.AddScoped<PublicClientRepository, PublicClientRepository>();
        webAssemblyHostBuilder.Services.AddScoped<PublicPersonRepository, PublicPersonRepository>();
        webAssemblyHostBuilder.Services.AddScoped<PublicFileRepository, PublicFileRepository>();
        webAssemblyHostBuilder.Services.AddScoped<PublicFileTypeRepository, PublicFileTypeRepository>();
        webAssemblyHostBuilder.Services.AddScoped<PublicAgeScaleRepository, PublicAgeScaleRepository>();
        webAssemblyHostBuilder.Services.AddScoped<PublicIncomeScaleRepository, PublicIncomeScaleRepository>();
        // Settings services.
        webAssemblyHostBuilder.Services.AddSingleton(new ApiSettings(webAssemblyHostBuilder.HostEnvironment.Environment));
    }
}