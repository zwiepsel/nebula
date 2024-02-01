using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nebula.Clients.FCB.Shared.Models.FileType;
using Nebula.Clients.FCB.Shared.Models.OnboardingState;
using Nebula.Clients.FCB.Shared.Models.Person;
using Nebula.Clients.FCB.Sites.MyFCB.Data;
using Nebula.Shared.Clients.Repositories;

namespace Nebula.Clients.FCB.Sites.MyFCB.Repositories;

public class PublicPersonRepository: BaseCrudRepository<PersonViewModel, PersonViewModel, PersonCreateModel, PersonUpdateModel>
{
    public PublicPersonRepository(AppApi api) : base(api, "person")
    {
    }
    
    public async Task CreatePersons(OnBoardingFamilyModel family, CancellationToken cancellationToken = default)
    { 
        await Api.PostAsync($"person/createPersons",family, cancellationToken);
    }
}