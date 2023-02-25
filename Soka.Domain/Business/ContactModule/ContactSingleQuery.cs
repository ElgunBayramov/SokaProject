using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class ContactSingleQuery : IRequest<ContactPost>
    {
        public int Id { get; set; }
        public class ContactSingleQueryHandler : IRequestHandler<ContactSingleQuery, ContactPost>
        {
            private readonly SokaDbContext db;

            public ContactSingleQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<ContactPost> Handle(ContactSingleQuery request, CancellationToken cancellationToken)
            {
                var data = await db.ContactPosts.FirstOrDefaultAsync(s => s.Id == request.Id && s.DeletedDate == null, cancellationToken);
                return data;
            }
        }
    }
}
