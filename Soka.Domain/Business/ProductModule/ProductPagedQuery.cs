using MediatR;
using Microsoft.EntityFrameworkCore;
using Soka.Application.AppCode.Infrastructure;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using Soka.Domain.Models.ViewModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.ProductModule
{
    public class ProductPagedQuery : PageableModel, IRequest<PagedViewModel<Product>>
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

        public class ProductsPagedQueryHandler : IRequestHandler<ProductPagedQuery, PagedViewModel<Product>>
        {
            private readonly SokaDbContext db;

            public ProductsPagedQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }

            public async Task<PagedViewModel<Product>> Handle(ProductPagedQuery request, CancellationToken cancellationToken)
            {
                var query = db.Products
                 .Where(m => m.DeletedDate == null)
                 .AsQueryable();

                query = query.OrderByDescending(m => m.Id);

                var data = new PagedViewModel<Product>(query, request.PageIndex, request.PageSize);

                return data;
            }
        }
    }
}
