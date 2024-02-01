
using System.Threading.Tasks;
using Nebula.Clients.FCB.Apps.Portal.Api.Domain.Entities;
using Nebula.Shared.Api.Repositories;

namespace Nebula.Clients.FCB.Apps.Portal.Api.Domain.Repositories;

public interface IPersonRepository : IBaseRepository<Person>
{
    public Task<string?> CalculateScale(decimal yearlyIncome);
}