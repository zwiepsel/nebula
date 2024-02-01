using System;
using Microsoft.Extensions.DependencyInjection;
using Nebula.Shared.Api.Console.Commands;
using Nebula.Shared.Api.Data;

namespace Nebula.Shared.Api.Console;

public class ConsoleCommandFactory<TDatabaseContext> where TDatabaseContext : IBaseDatabaseContext
{
    private readonly string commandName;
    private readonly IServiceProvider serviceProvider;

    public ConsoleCommandFactory(string[] arguments, IServiceProvider serviceProvider)
    {
        commandName = arguments[0];
        this.serviceProvider = serviceProvider;
    }

    public IConsoleCommand Create()
    {
        return commandName.ToLower() switch
        {
            UpdateDatabaseCommand<TDatabaseContext>.Name => (UpdateDatabaseCommand<TDatabaseContext>)
                serviceProvider.GetRequiredService(typeof(UpdateDatabaseCommand<TDatabaseContext>)),
            _ => throw new InvalidOperationException($"Invalid command: '{commandName}'")
        };
    }
}