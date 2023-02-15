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

namespace Soka.Domain.Business.BlogPostModule
{
    public class BlogPostsAllQuery : IRequest<List<BlogPost>>
    {
        public class BlogPostsAllQueryHandler : IRequestHandler<BlogPostsAllQuery, List<BlogPost>>
        {
            private readonly SokaDbContext db;

            public BlogPostsAllQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<BlogPost>> Handle(BlogPostsAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.BlogPosts.Where(m=>m.DeletedDate==null)
                    .ToListAsync(cancellationToken);
                return data;
            }
        }
    }
}
