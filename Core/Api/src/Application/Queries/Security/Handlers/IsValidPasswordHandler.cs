using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Core.Api.Domain.Security;

namespace Nebula.Core.Api.Application.Queries.Security.Handlers;

public class IsValidPasswordHandler : IRequestHandler<IsValidPasswordQuery, bool>
{
    private readonly PasswordManager passwordManager;

    public IsValidPasswordHandler(PasswordManager passwordManager)
    {
        this.passwordManager = passwordManager;
    }

    public async Task<bool> Handle(IsValidPasswordQuery request, CancellationToken cancellationToken)
    {
        if (request.User != null)
        {
            return await passwordManager.CheckPassword(request.User, request.Password);
        }

        if (request.SiteUser != null)
        {
            return await passwordManager.CheckPassword(request.SiteUser, request.Password);
        }

        return false;
    }
}