using System.Threading.Tasks;

namespace Nebula.Shared.Validation;

public interface IDataValidator
{
    public Task<bool> UniqueUserName(string userName);
    public Task<bool> UniqueEmailAddress(string emailAddress);
}