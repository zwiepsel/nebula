using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Nebula.Shared.Api.Settings;
using Nebula.Shared.Models.Security;

namespace Nebula.Core.Api.Application.Queries.Security.Handlers;

public class GetApiTokenHandler : IRequestHandler<GetApiTokenQuery, ApiTokenModel>
{
    private readonly ApiSettings apiSettings;
    private readonly UserManager<Domain.Entities.Identity.User> userManager;

    public GetApiTokenHandler(UserManager<Domain.Entities.Identity.User> userManager, ApiSettings apiSettings)
    {
        this.userManager = userManager;
        this.apiSettings = apiSettings;
    }

    public async Task<ApiTokenModel> Handle(GetApiTokenQuery request, CancellationToken cancellationToken)
    {
        var user = request.User;
        var siteUser = request.SiteUser;

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Sid, request.Site.Id.ToString()),
            new(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, user.Email),
            new(JwtRegisteredClaimNames.Email, user.Email)
        };

        // Add the user roles to the claims.
        foreach (var roleName in await userManager.GetRolesAsync(user))
        {
            claims.Add(new Claim(ClaimTypes.Role, roleName));
        }

        if (siteUser != null)
        {
            // Add the site user role to the claims.
            claims.Add(new Claim(ClaimTypes.Role, siteUser.Role.Name));
        }

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(apiSettings.Key));
        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var securityToken = new JwtSecurityToken(
            apiSettings.Issuer,
            apiSettings.Audience,
            expires: DateTime.Now.AddSeconds(apiSettings.LifeTime),
            claims: claims,
            signingCredentials: signingCredentials
        );

        var apiToken = new ApiTokenModel
        {
            Token = new JwtSecurityTokenHandler().WriteToken(securityToken), Expiration = securityToken.ValidTo
        };

        return apiToken;
    }
}