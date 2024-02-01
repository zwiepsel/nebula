﻿using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.File.Handlers;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.File;

/// <see cref="DeleteFileHandler" />
public class DeleteFileCommand : IRequest
{
    public DeleteFileCommand(Domain.Entities.File file)
    {
        File = file;
    }

    public Domain.Entities.File File { get; }
}