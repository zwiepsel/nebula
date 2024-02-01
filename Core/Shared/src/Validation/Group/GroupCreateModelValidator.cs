using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Nebula.Shared.Models.Group;
using Nebula.Shared.Validation;

namespace Nebula.Core.Shared.Validation.Group;

public class GroupCreateModelValidator : ModelValidator<GroupCreateModel>
{
    private readonly IRemoteDataValidator remoteDataValidator;

    public GroupCreateModelValidator(IRemoteDataValidator remoteDataValidator)
    {
        this.remoteDataValidator = remoteDataValidator;

        RuleFor(m => m.Name).IsRequired("Name");
        RuleFor(m => m.SystemName).IsRequired("System name")
            .Matches("^[a-z0-9_]+$").WithMessage("System name can only contain lowercase letters, numbers and underscores.")
            .MustAsync(BeUniqueGroupSystemName).WithMessage("System name already taken.");
    }

    private async Task<bool> BeUniqueGroupSystemName(string groupSystemName, CancellationToken cancellationToken = default)
    {
        return await remoteDataValidator.UniqueGroupSystemName(groupSystemName);
    }
}