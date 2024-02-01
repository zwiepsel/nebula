using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Data;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.FileSystem;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Settings;
using Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Data;
using Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.FileSystem;
using Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Repositories;
using Nebula.Shared.Api.Startup;

namespace Nebula.Clients.FCB.Apps.Portal.Api;

public class Startup : BaseStartup<Startup, DatabaseContext, FCB.Shared.Shared, ClientSettings>
{
    public Startup(IConfiguration configuration) : base(configuration, configuration.GetSection("Client").Get<ClientSettings>())
    {
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection serviceCollection)
    {
        ConfigureDefaultAppServices(serviceCollection);

        // Configuration services.
        serviceCollection.AddSingleton(ClientSettings);

        // Data services.
        serviceCollection.AddScoped<IDatabaseContext, DatabaseContext>();

        // Repository services.
        serviceCollection.AddScoped<IClientRepository, ClientRepository>();
        serviceCollection.AddScoped<IComplexRepository, ComplexRepository>();
        serviceCollection.AddScoped<IHouseRepository, HouseRepository>();
        serviceCollection.AddScoped<IIncomeRepository, IncomeRepository>();
        serviceCollection.AddScoped<ILeaseAgreementRepository, LeaseAgreementRepository>();
        serviceCollection.AddScoped<INeighborhoodRepository, NeighborhoodRepository>();
        serviceCollection.AddScoped<IPersonRepository, PersonRepository>();
        serviceCollection.AddScoped<IRentRepository, RentRepository>();
        serviceCollection.AddScoped<IFileRepository, FileRepository>();
        serviceCollection.AddScoped<IFileTypeRepository, FileTypeRepository>();
        serviceCollection.AddScoped<IAgeScaleRepository, AgeScaleRepository>();
        serviceCollection.AddScoped<IIncomeScaleRepository, IncomeScaleRepository>();
        
        // File services.
        serviceCollection.AddScoped<IFileSystem, FileSystem>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
    {
        ConfigureDefaults(applicationBuilder, webHostEnvironment);
    }
}