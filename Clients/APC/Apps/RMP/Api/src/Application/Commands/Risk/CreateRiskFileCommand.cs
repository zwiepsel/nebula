using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk.Handlers;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Risk;

/// <see cref="CreateRiskFileHandler" />
public class CreateRiskFileCommand : IRequest<Domain.Entities.Risk>
{
    public CreateRiskFileCommand(Domain.Entities.Risk risk, Domain.Entities.File file)
    {
        Risk = risk;
        File = file;
    }

    public Domain.Entities.Risk Risk { get; }
    public Domain.Entities.File File { get; }
}