using Soka.Application.AppCode.Extensions;
using Soka.Domain.Models.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.AccountModule
{
    public class SigninCommand : IRequest<SokaUser>
    {
        public string UserName { get; set; }
        public string Password { get; set; }


        public class SigninCommandHandler : IRequestHandler<SigninCommand, SokaUser>
        {
            private readonly SignInManager<SokaUser> signinManager;
            private readonly IActionContextAccessor ctx;

            public SigninCommandHandler(SignInManager<SokaUser> signinManager, IActionContextAccessor ctx)
            {
                this.signinManager = signinManager;
                this.ctx = ctx;
            }


            public async Task<SokaUser> Handle(SigninCommand request, CancellationToken cancellationToken)
            {
                SokaUser user = null;


                if (request.UserName.IsEmail())
                {
                    user = await signinManager.UserManager.FindByEmailAsync(request.UserName);
                }
                else
                {
                    user = await signinManager.UserManager.FindByNameAsync(request.UserName);
                }


                if (user == null)
                {
                    ctx.ActionContext.ModelState.AddModelError("UserName", "Istifadeci adi ve ya sifre sehvdir");

                    return null;
                }

                var result = await signinManager.CheckPasswordSignInAsync(user, request.Password, true);


                if (result.IsLockedOut)
                {
                    ctx.ActionContext.ModelState.AddModelError("UserName", "Hesabibiz kecici olaraq mehdudlashdirilib");

                    return null;
                }


                if (result.IsNotAllowed)
                {
                    ctx.ActionContext.ModelState.AddModelError("UserName", "Hesaba daxil olmaq mumkun deyil");

                    return null;
                }



                if (!user.EmailConfirmed)
                {
                    ctx.ActionContext.ModelState.AddModelError("UserName", "Hesabiniz tesdiq edilmeyib");

                    return null;
                }


                if (result.Succeeded)
                {
                    return user;
                }

                ctx.ActionContext.ModelState.AddModelError("UserName", "Istifadeci adi ve ya sifre sehvdir");
                return null;
            }
        }
    }
}
