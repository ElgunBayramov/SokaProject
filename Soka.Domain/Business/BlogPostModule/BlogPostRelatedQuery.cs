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
    public class BlogPostRelatedQuery : IRequest<List<BlogPost>>
    {
        public int PostId { get; set; }
        public int Size { get; set; }
        public class BlogpostRelatedQueryHandler : IRequestHandler<BlogPostRelatedQuery, List<BlogPost>>
    {
            private readonly SokaDbContext db;

            public BlogpostRelatedQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<BlogPost>> Handle(BlogPostRelatedQuery request, CancellationToken cancellationToken)
            {
                var tagIds = await db.BlogPostTagCloud.Where(b => b.BlogPostId == request.PostId)
                    .Select(b=>b.TagId)
                    .ToArrayAsync(cancellationToken);

                var relatedBlogPostIds = await db.BlogPostTagCloud.Where(b=>tagIds.Contains(b.TagId) && b.BlogPostId != request.PostId)
                    .Select(b => b.BlogPostId)
                    .Distinct()
                    .ToArrayAsync(cancellationToken);

                var relatedPosts = await db.BlogPosts.Where(bp => relatedBlogPostIds.Contains(bp.Id)
                && bp.DeletedDate == null
                && bp.PublishDate != null)
                .OrderByDescending(bp => bp.PublishDate)
                .Take(request.Size <= 2 ? 2 : request.Size)
                .ToListAsync(cancellationToken);
                
                return relatedPosts;
            }
        }
    }
}
