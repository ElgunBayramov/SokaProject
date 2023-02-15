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

namespace Soka.Domain.Business.TagModule
{
    public class TagsAllQuery : IRequest<List<Tag>>
    {
        public class TagsAllQueryHandler : IRequestHandler<TagsAllQuery, List<Tag>>
        {
            private readonly SokaDbContext db;

            public TagsAllQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Tag>> Handle(TagsAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Tags.Where(m => m.DeletedDate == null)
                    .ToListAsync(cancellationToken);
                return data;
            }
        }
    }
}
