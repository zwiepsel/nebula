using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Nebula.Shared.Models.Permission;
using Nebula.Shared.Validation;

namespace Nebula.Core.Shared.Validation.Permission;

public class PermissionCreateModelValidator : ModelValidator<PermissionCreateModel>
{
    private readonly IRemoteDataValidator remoteDataValidator;

    public PermissionCreateModelValidator(IRemoteDataValidator remoteDataValidator)
    {
        this.remoteDataValidator = remoteDataValidator;

        RuleFor(m => m.Name).IsRequired("Name");
        RuleFor(m => m.SystemName).IsRequired("System name")
            .Matches("^[a-z0-9_]+$").WithMessage("System name can only contain lowercase letters, numbers and underscores.")
            .MustAsync(BeUniquePermissionSystemName).WithMessage("System name already taken.");
    }

    private async Task<bool> BeUniquePermissionSystemName(string permissionSystemName, CancellationToken cancellationToken = default)
    {
        return await remoteDataValidator.UniquePermissionSystemName(permissionSystemName);
    }
}