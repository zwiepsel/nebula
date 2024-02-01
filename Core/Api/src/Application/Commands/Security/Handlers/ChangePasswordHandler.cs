using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Nebula.Core.Api.Domain.Security;

namespace Nebula.Core.Api.Application.Commands.Security.Handlers
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, IdentityResult>
    {
        private readonly PasswordManager passwordManager;

        public ChangePasswordHandler(PasswordManager passwordManager)
        {
            this.passwordManager = passwordManager;
        }

        public async Task<IdentityResult> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = request.User;
            var siteUser = request.SiteUser;
            var changePasswordModel = request.ChangePasswordModel;

            if (user != null)
            {
                return await passwordManager.ChangePassword(user, changePasswordModel.CurrentPassword!, changePasswordModel.NewPassword!);
            }

            if (siteUser != null)
            {
                return await passwordManager.ChangePassword(siteUser, changePasswordModel.CurrentPassword!, changePasswordModel.NewPassword!);
            }

            return IdentityResult.Failed();
        }
    }
}