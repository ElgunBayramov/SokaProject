using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Soka.Application.AppCode.Infrastructure;
using Soka.Domain.Models.ViewModels;

namespace Soka.Domain.Business.BlogPostModule
{
    public class BlogPostByTagQuery : PageableModel,IRequest<PagedViewModel<BlogPost>>
    {
        public override int PageSize
        {
            get
            {
                if (base.PageSize < 3)
                    base.PageSize = 3;

                return base.PageSize;
            }
        }
        public int TagId { get; set; }
        public class BlogPostsAllQueryHandler : IRequestHandler<BlogPostByTagQuery, PagedViewModel<BlogPost>>
        {
            private readonly SokaDbContext db;

            public BlogPostsAllQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }

            public async Task<PagedViewModel<BlogPost>> Handle(BlogPostByTagQuery request, CancellationToken cancellationToken)
            {
                var query = (from bp in db.BlogPosts
                                  join tc in db.BlogPostTagCloud on bp.Id equals tc.BlogPostId
                                  where tc.TagId == request.TagId
                                  select bp)
                            .Distinct()
                            .AsQueryable();
                query = query.OrderBy(m=>m.PublishDate);
                var data = new PagedViewModel<BlogPost>(query, request.PageIndex, request.PageSize);
                return data;
            }
        }
    }
}
