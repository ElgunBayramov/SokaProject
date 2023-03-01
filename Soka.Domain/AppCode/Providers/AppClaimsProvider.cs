using MediatR;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Soka.Domain.Business.AccountModule;

namespace Soka.Application.AppCode.Providers
{
    public class AppClaimsProvider : IClaimsTransformation
    {
        public static string[] policies = null;
        private readonly IMediator mediator;

        public AppClaimsProvider(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal.Identity.IsAuthenticated)
            {
                var query = new ReloadAuthorityQuery
                {
                    User = principal,
                };
                await mediator.Send(query);
            }
            return principal;
        }
    }
}
