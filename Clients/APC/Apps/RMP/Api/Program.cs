using Nebula.Clients.APC.Apps.RMP.Api.Infrastructure.Data;
using Nebula.Shared.Api.Hosting;

namespace Nebula.Clients.APC.Apps.RMP.Api;

public class Program : BaseProgram<DatabaseContext, Startup>
{
    public static void Main(string[] args)
    {
        Start(args);
    }
}