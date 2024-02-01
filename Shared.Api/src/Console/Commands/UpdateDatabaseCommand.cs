using Nebula.Shared.Api.Data;

namespace Nebula.Shared.Api.Console.Commands;

public class UpdateDatabaseCommand<TDatabaseContext> : IConsoleCommand where TDatabaseContext : IBaseDatabaseContext
{
    public const string Name = "database:update";

    private readonly TDatabaseContext databaseContext;

    public UpdateDatabaseCommand(TDatabaseContext databaseContext)
    {
        this.databaseContext = databaseContext;
    }

    public void Run()
    {
        System.Console.WriteLine("Updating database...");
        databaseContext.Migrate();
        System.Console.WriteLine("Database updated.");
    }
}