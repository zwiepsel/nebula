﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.Client.Handlers;

public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<Domain.Entities.Client>>
{
    private readonly IClientRepository clientRepository;

    public GetAllClientsHandler(IClientRepository clientRepository)
    {
        this.clientRepository = clientRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Client>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
    {
        return await clientRepository.FindAll(false, cancellationToken);
    }
}