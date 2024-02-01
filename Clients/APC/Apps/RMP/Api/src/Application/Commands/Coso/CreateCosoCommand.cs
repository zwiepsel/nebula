using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Coso.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Coso;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Coso;

/// <see cref="CreateCosoHandler" />
public class CreateCosoCommand : IRequest<Domain.Entities.Coso>
{
    public CreateCosoCommand(CosoCreateModel cosoCreateModel)
    {
        CosoCreateModel = cosoCreateModel;
    }

    public CosoCreateModel CosoCreateModel { get; }
}