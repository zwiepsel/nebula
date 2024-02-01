using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Coso.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Coso;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Coso;

/// <see cref="UpdateCosoHandler" />
public class UpdateCosoCommand : IRequest<Domain.Entities.Coso>
{
    public UpdateCosoCommand(Domain.Entities.Coso coso, CosoUpdateModel cosoUpdateModel)
    {
        Coso = coso;
        CosoUpdateModel = cosoUpdateModel;
    }

    public Domain.Entities.Coso Coso { get; }
    public CosoUpdateModel CosoUpdateModel { get; }
}