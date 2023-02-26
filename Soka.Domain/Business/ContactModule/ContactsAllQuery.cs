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
    public class ContactsAllQuery : IRequest<List<ContactPost>>
    {
        public class ContactsAllQueryHandler : IRequestHandler<ContactsAllQuery, List<ContactPost>>
        {
            private readonly SokaDbContext db;

            public ContactsAllQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<ContactPost>> Handle(ContactsAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.ContactPosts.Where(m => m.DeletedDate == null)
                    .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
