using Soka.Domain.Models.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.UserModule
{
    public class UserDetailQuery : IRequest<SokaUser>
    {
        public int Id { get; set; }


        public class UserDetailQueryHandler : IRequestHandler<UserDetailQuery, SokaUser>
        {
            private readonly UserManager<SokaUser> userManager;

            public UserDetailQueryHandler(UserManager<SokaUser> userManager)
            {
                this.userManager = userManager;
            }

            public async Task<SokaUser> Handle(UserDetailQuery request, CancellationToken cancellationToken)
            {
                var data = await userManager.Users.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);


                return data;
            }
        }
    }
}
