using MediatR;
using Soka.Application.AppCode.Infrastructure;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using Soka.Domain.Models.ViewModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.CategoryModule
{
    public class CategoryPagedQuery : PageableModel, IRequest<PagedViewModel<Category>>
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

        public class CategorysPagedQueryHandler : IRequestHandler<CategoryPagedQuery, PagedViewModel<Category>>
        {
            private readonly SokaDbContext db;

            public CategorysPagedQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }

            public async Task<PagedViewModel<Category>> Handle(CategoryPagedQuery request, CancellationToken cancellationToken)
            {
                var query = db.Categories
                 .Where(m => m.DeletedDate == null)
                 .AsQueryable();

                query = query.OrderByDescending(m => m.Id);

                var data = new PagedViewModel<Category>(query, request.PageIndex, request.PageSize);

                return data;
            }
        }
    }
}
