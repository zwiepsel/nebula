using System;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nebula.Shared.Api.Console;
using Nebula.Shared.Api.Data;

namespace Nebula.Shared.Api.Hosting;

public abstract class BaseProgram<TDatabaseContext, TStartup> where TDatabaseContext : IBaseDatabaseContext where TStartup : class
{
    protected static void Start(string[] args)
    {
        var webHost = CreateHostBuilder(args).Build();

        RunConsoleCommands(args, webHost.Services);

        if (args.IsNullOrEmpty())
        {
            webHost.Run();
        }
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var hostBuilder = Host.CreateDefaultBuilder(args);

        hostBuilder.ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<TStartup>();
            webBuilder.UseSentry();
        });

        return hostBuilder;
    }

    private static void RunConsoleCommands(string[] arguments, IServiceProvider serviceProvider)
    {
        if (arguments.IsNullOrEmpty())
        {
            return;
        }

        using var scope = serviceProvider.CreateScope();
        var consoleCommandFactory = new ConsoleCommandFactory<TDatabaseContext>(arguments, scope.ServiceProvider);

        consoleCommandFactory.Create().Run();
    }
}