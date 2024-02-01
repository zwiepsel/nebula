using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Income.Handlers;

public class CreateIncomeHandler : IRequestHandler<CreateIncomeCommand, Domain.Entities.Income>
{
    private readonly IIncomeRepository incomeRepository;
    private readonly IMapper mapper;

    public CreateIncomeHandler(IIncomeRepository incomeRepository, IMapper mapper)
    {
        this.incomeRepository = incomeRepository;
        this.mapper = mapper;
    }

    public async Task<Domain.Entities.Income> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Domain.Entities.Income>(request.CreateModel);

        incomeRepository.Add(entity);
        await incomeRepository.SaveChangesAsync(cancellationToken);

        return incomeRepository.Refresh(entity);
    }
}