using MediatR;
using Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Firm.Handlers;
using Nebula.Clients.APC.Apps.RMP.Shared.Models.Firm;

namespace Nebula.Clients.APC.Apps.RMP.Api.Application.Commands.Firm;

/// <see cref="CreateFirmHandler" />
public class CreateFirmCommand : IRequest<Domain.Entities.Firm>
{
    public CreateFirmCommand(FirmCreateModel firmCreateModel)
    {
        FirmCreateModel = firmCreateModel;
    }

    public FirmCreateModel FirmCreateModel { get; }
}