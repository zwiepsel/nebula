using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Nebula.Core.Api.Domain.Entities;
using Nebula.Core.Api.Domain.Entities.Identity;
using Nebula.Core.Api.Domain.Repositories;
using Nebula.Shared.Utilities;

namespace Nebula.Core.Api.Domain.Security;

public class PasswordManager
{
    private readonly UserManager<User> userManager;
    private readonly ISiteUserRepository siteUserRepository;

    public PasswordManager(UserManager<User> userManager, ISiteUserRepository siteUserRepository)
    {
        this.userManager = userManager;
        this.siteUserRepository = siteUserRepository;
    }

    public async Task<bool> CheckPassword(User user, string password)
    {
        return await userManager.CheckPasswordAsync(user, password);
    }

    public async Task<bool> CheckPassword(SiteUser siteUser, string password)
    {
        var passwordHasher = new PasswordHasher<SiteUser>();
        var passwordVerificationResult = passwordHasher.VerifyHashedPassword(siteUser, siteUser.PasswordHash, password);

        if (passwordVerificationResult == PasswordVerificationResult.Failed)
        {
            return false;
        }

        if (passwordVerificationResult == PasswordVerificationResult.Success)
        {
            return true;
        }

        if (passwordVerificationResult == PasswordVerificationResult.SuccessRehashNeeded)
        {
            await ChangePassword(siteUser, password);

            return true;
        }

        return false;
    }

    public async Task<IdentityResult> ChangePassword(User user, string currentPassword, string newPassword)
    {
        return await userManager.ChangePasswordAsync(user, currentPassword, newPassword);
    }

    public async Task<IdentityResult> ChangePassword(SiteUser siteUser, string currentPassword, string newPassword)
    {
        if (!await CheckPassword(siteUser, currentPassword))
        {
            return IdentityResult.Failed();
        }

        await ChangePassword(siteUser, newPassword);

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> SetPassword(SiteUser siteUser, string password)
    {
        await ChangePassword(siteUser, password);

        return IdentityResult.Success;
    }

    private async Task ChangePassword(SiteUser siteUser, string password)
    {
        var passwordHasher = new PasswordHasher<SiteUser>();

        siteUser.PasswordHash = passwordHasher.HashPassword(siteUser, password);
        siteUser.SecurityStamp = HashGenerator.Sha256(Guid.NewGuid().ToString()).ToUpper();

        siteUserRepository.Update(siteUser);
        await siteUserRepository.SaveChangesAsync();
    }
}