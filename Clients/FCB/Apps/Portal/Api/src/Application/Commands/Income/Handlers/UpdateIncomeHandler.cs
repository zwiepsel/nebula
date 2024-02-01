using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Income.Handlers;

public class UpdateIncomeHandler : IRequestHandler<UpdateIncomeCommand, Domain.Entities.Income>
{
    private readonly IIncomeRepository incomeRepository;
    private readonly IMapper mapper;

    public UpdateIncomeHandler(IIncomeRepository incomeRepository, IMapper mapper)
    {
        this.incomeRepository = incomeRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Income> Handle(UpdateIncomeCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map(request.UpdateModel, request.Entity);

        incomeRepository.Update(entity);
        await incomeRepository.SaveChangesAsync(cancellationToken);

        return entity;
    }
}