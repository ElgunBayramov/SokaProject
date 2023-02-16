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
    public class BlogPostRecentQuery : IRequest<List<BlogPost>>
    {
        public int Size { get; set; }
        public class BlogPostRecentQueryHandler : IRequestHandler<BlogPostRecentQuery, List<BlogPost>>
        {
            private readonly SokaDbContext db;

            public BlogPostRecentQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<BlogPost>> Handle(BlogPostRecentQuery request, CancellationToken cancellationToken)
            {
                var data = await db.BlogPosts
                    .Where(m => m.DeletedDate == null)
                    .OrderByDescending(m => m.PublishDate)
                    .Take(request.Size < 2 ? 2 : request.Size)
                    .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
