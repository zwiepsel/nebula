using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Firm.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Firm;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Firm;

/// <see cref="UpdateFirmHandler" />
public class UpdateFirmCommand : IRequest<Domain.Entities.Firm>
{
    public UpdateFirmCommand(Domain.Entities.Firm firm, FirmUpdateModel firmUpdateModel)
    {
        Firm = firm;
        FirmUpdateModel = firmUpdateModel;
    }

    public Domain.Entities.Firm Firm { get; }
    public FirmUpdateModel FirmUpdateModel { get; }
}