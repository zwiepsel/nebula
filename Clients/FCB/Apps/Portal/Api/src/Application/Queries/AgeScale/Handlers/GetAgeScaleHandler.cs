using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Queries.AgeScale.Handlers;

public class GetAgeScaleHandler: IRequestHandler<GetAgeScaleQuery, IEnumerable<Domain.Entities.AgeScale>>
{
    private readonly IAgeScaleRepository ageScaleRepositoryy;

    public GetAgeScaleHandler(IAgeScaleRepository ageScaleRepositoryy)
    {
        this.ageScaleRepositoryy = ageScaleRepositoryy;
    }

    public async Task<IEnumerable<Domain.Entities.AgeScale>> Handle(GetAgeScaleQuery request, CancellationToken cancellationToken)
    {
        return await ageScaleRepositoryy.FindAll(false, cancellationToken);
    }
}