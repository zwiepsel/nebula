using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;
using Nebula.Clients.FCB.Shared.Enums;
using Nebula.Shared.Extensions;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Application.Commands.Person.Handlers;

public class CalculateFieldsHandler : IRequestHandler<CalculateFieldsCommand, Domain.Entities.Client>
{
    public IPersonRepository PersonRepository { get; }
    public IClientRepository ClientRepository { get; }

    public CalculateFieldsHandler(IPersonRepository personRepository, IClientRepository clientRepository)
    {
        PersonRepository = personRepository;
        ClientRepository = clientRepository;
    }

    public async Task<Domain.Entities.Client> Handle(CalculateFieldsCommand request, CancellationToken cancellationToken)
    {
        var client = await ClientRepository.FindById(request.ClientId, cancellationToken);
        if (client != null)
        {
            client.MinorQty = 0;
            client.ChildrenQty = 0;
            client.AdultQty = 0;
            client.ChildDiscount = 0;
            client.YearlyIncome = 0;
            var persons = client.Persons.Where(x => x.RelationType == RelationType.Family && x.Deleted == false);
            foreach (var person in persons)
            {
                var age = person.DateOfBirth.ToAge();
                if (age >= 18 && person.SchoolGoing == false)
                {
                    client.AdultQty++;
                }
                if (age < 18 || (age < 27 && person.SchoolGoing))
                {
                    client.ChildrenQty++;
                }

                if (age < 18)
                {
                    client.MinorQty++;
                }

                if (person.Incomes != null)
                {
                    foreach (var personIncome in person.Incomes)
                    {

                        client.YearlyIncome += personIncome.YearlyAmount;
                    }
                }

            }
            client.ChildDiscount += Convert.ToDecimal(0.5) * client.ChildrenQty;
            client.YearlyIncomeClass = await PersonRepository.CalculateScale(client.YearlyIncome);
            ClientRepository.Update(client);
            await ClientRepository.SaveChangesAsync(cancellationToken);
        }
        return client!;
    }
    
}