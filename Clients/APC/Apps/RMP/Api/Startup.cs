using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Data;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Email;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.FileSystem;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Repositories;
using Nebula.Clients.APC.Apps.RMP.Api.Domain.Settings;
using Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Data;
using Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Email;
using Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.FileSystem;
using Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Repositories;
using Nebula.Shared.Api.Startup;
using Nebula.Shared.Api.Utilities;

namespace Nebula.Clients.APC.Apps.RMP.Api;

public class Startup : BaseStartup<Startup, DatabaseContext, Shared.Shared, ClientSettings>
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
        // serviceCollection.AddSingleton(Configuration.GetSection("Email").Get<EmailSettings>());

        // Data services.
        serviceCollection.AddScoped<IDatabaseContext, DatabaseContext>();

        // Repository services.
        serviceCollection.AddScoped<ICosoRepository, CosoRepository>();
        serviceCollection.AddScoped<IDepartmentRepository, DepartmentRepository>();
        serviceCollection.AddScoped<IFileRepository, FileRepository>();
        serviceCollection.AddScoped<IFileTypeRepository, FileTypeRepository>();
        serviceCollection.AddScoped<IFirmRepository, FirmRepository>();
        serviceCollection.AddScoped<IMitigationControlRepository, MitigationControlRepository>();
        serviceCollection.AddScoped<IProcessRepository, ProcessRepository>();
        serviceCollection.AddScoped<IRiskMitigationControlRepository, RiskMitigationControlRepository>();
        serviceCollection.AddScoped<IRiskPossibleOptimizationRepository, RiskPossibleOptimizationRepository>();
        serviceCollection.AddScoped<IRiskRepository, RiskRepository>();
        serviceCollection.AddScoped<IRiskScoreRepository, RiskScoreRepository>();

        // File services.
        serviceCollection.AddScoped<IFileSystem, FileSystem>();

        // Other services.
        serviceCollection.AddTransient<IMailer, Mailer>();
        serviceCollection.AddTransient<ViewRenderer, ViewRenderer>();

        // Cron jobs.
        // var cronJobSettings = Configuration.GetSection("CronJobs").Get<CronJobSettings>();
        //
        // serviceCollection.AddCronJob<SendEmailMessagesCronJob>(options =>
        // {
        //     options.CronExpression = cronJobSettings.SendEmailMessagesCronExpression;
        //     options.NotificationUri = cronJobSettings.SendEmailMessagesNotificationUri;
        // });
        // serviceCollection.AddCronJob<SendRiskRemindersCronJob>(options =>
        // {
        //     options.CronExpression = cronJobSettings.SendRiskRemindersCronExpression;
        //     options.NotificationUri = cronJobSettings.SendRiskRemindersNotificationUri;
        // });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
    {
        ConfigureDefaults(applicationBuilder, webHostEnvironment);
    }
}