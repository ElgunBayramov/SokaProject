using MediatR;
using Microsoft.EntityFrameworkCore;
using Soka.Application.AppCode.Infrastructure;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using Soka.Domain.Models.ViewModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.BlogPostModule
{
    public class BlogPostPagedQuery : PageableModel, IRequest<PagedViewModel<BlogPost>>
    {
        public override int PageSize
        {
            get
            {
                if (base.PageSize < 6)
                    base.PageSize = 6;

                return base.PageSize;
            }
        }

        public class BlogPostsPagedQueryHandler : IRequestHandler<BlogPostPagedQuery, PagedViewModel<BlogPost>>
        {
            private readonly SokaDbContext db;

            public BlogPostsPagedQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }

            public async Task<PagedViewModel<BlogPost>> Handle(BlogPostPagedQuery request, CancellationToken cancellationToken)
            {
                var query = db.BlogPosts
                 .Where(m => m.DeletedDate == null)
                 .AsQueryable();

                query = query.OrderByDescending(m => m.PublishDate);

                var data = new PagedViewModel<BlogPost>(query, request.PageIndex, request.PageSize);

                return data;
            }
        }
    }
}
