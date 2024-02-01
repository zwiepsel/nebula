using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Person.Handlers;

public class DeletePersonHandler : AsyncRequestHandler<DeletePersonCommand>
{
    private readonly IPersonRepository personRepository;

    public DeletePersonHandler(IPersonRepository personRepository)
    {
        this.personRepository = personRepository;
    }

    protected override async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        personRepository.Delete(request.Person);
        await personRepository.SaveChangesAsync(cancellationToken);
    }
}