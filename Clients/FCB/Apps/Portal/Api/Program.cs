using Nebula.Clients.FCB.Apps.Portal.Api.Infrastructure.Data;
using Nebula.Shared.Api.Hosting;

namespace Nebula.Clients.FCB.Apps.Portal.Api;

public class Program : BaseProgram<DatabaseContext, Startup>
{
    public static void Main(string[] args)
    {
        Start(args);
    }
}