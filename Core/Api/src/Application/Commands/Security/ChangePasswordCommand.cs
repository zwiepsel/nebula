using MediatR;
using Microsoft.AspNetCore.Identity;
using Nebula.Core.Api.Application.Commands.Security.Handlers;
using Nebula.Shared.Models.Security;

namespace Nebula.Core.Api.Application.Commands.Security
{
    /// <see cref="ChangePasswordHandler"/>
    public class ChangePasswordCommand : IRequest<IdentityResult>
    {
        public Domain.Entities.Identity.User? User { get; }
        public Domain.Entities.SiteUser? SiteUser { get; }
        public ChangePasswordModel ChangePasswordModel { get; }

        public ChangePasswordCommand(Domain.Entities.Identity.User user, ChangePasswordModel changePasswordModel)
        {
            User = user;
            ChangePasswordModel = changePasswordModel;
        }

        public ChangePasswordCommand(Domain.Entities.SiteUser siteUser, ChangePasswordModel changePasswordModel)
        {
            SiteUser = siteUser;
            ChangePasswordModel = changePasswordModel;
        }
    }
}