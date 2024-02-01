using Nebula.Core.Api.Infrastructure.Data;
using Nebula.Shared.Api.Hosting;

namespace Nebula.Core.Api;

public class Program : BaseProgram<DatabaseContext, Startup>
{
    public static void Main(string[] args)
    {
        Start(args);
    }
}