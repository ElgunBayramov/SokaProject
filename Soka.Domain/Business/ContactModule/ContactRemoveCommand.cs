using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Soka.Application.AppCode.Infrastructure;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.ContactModule
{
    public class ContactRemoveCommand : IRequest<JsonResponse>
    {
        public int Id { get; set; }

        public class ContactRemoveCommandHandler : IRequestHandler<ContactRemoveCommand, JsonResponse>
        {
            private readonly SokaDbContext db;
            private readonly IActionContextAccessor ctx;

            public ContactRemoveCommandHandler(SokaDbContext db, IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }
            public async Task<JsonResponse> Handle(ContactRemoveCommand request, CancellationToken cancellationToken)
            {

                var data = await db.ContactPosts
                    .FirstOrDefaultAsync(s => s.Id == request.Id && s.DeletedDate == null, cancellationToken);

                if (data == null)
                {
                    return new JsonResponse
                    {
                        Error = true,
                        Message = "Qeyd tapılmadı"
                    };
                }

                data.DeletedDate = DateTime.UtcNow.AddHours(4);

                await db.SaveChangesAsync(cancellationToken);

                return new JsonResponse
                {
                    Error = false,
                    Message = "Uğurludur"
                };
            }
        }
    }
}
