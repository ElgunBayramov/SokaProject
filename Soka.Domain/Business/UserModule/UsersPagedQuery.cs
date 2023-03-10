using MediatR;
using Microsoft.AspNetCore.Identity;
using Soka.Application.AppCode.Infrastructure;
using Soka.Domain.Models.Entities.Membership;
using Soka.Domain.Models.ViewModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.UserModule
{
    public class UsersPagedQuery : PageableModel, IRequest<PagedViewModel<SokaUser>>
    {
        public override int PageSize
        {
            get
            {
                return base.PageSize;
            }
            set
            {
                if (value <= 15)
                {
                    base.PageSize = 15;
                }
                else
                {
                    base.PageSize = value;
                }
            }
        }


        public class UsersPagedQueryHandler : IRequestHandler<UsersPagedQuery, PagedViewModel<SokaUser>>
        {
            private readonly UserManager<SokaUser> userManager;

            public UsersPagedQueryHandler(UserManager<SokaUser> userManager)
            {
                this.userManager = userManager;
            }

            public Task<PagedViewModel<SokaUser>> Handle(UsersPagedQuery request, CancellationToken cancellationToken)
            {
                var query = userManager.Users
                    .OrderBy(m => m.EmailConfirmed)
                    .ThenByDescending(m => m.Id);


                var pagedData = new PagedViewModel<SokaUser>(query, request.PageIndex, request.PageSize);

                return Task.FromResult(pagedData);
            }
        }
    }
}
