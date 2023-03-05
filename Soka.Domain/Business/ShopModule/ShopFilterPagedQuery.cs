using MediatR;
using Soka.Application.AppCode.Infrastructure;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using Soka.Domain.Models.ViewModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.ShopModule
{
    public class ShopFilterPagedQuery : PageableModel, IRequest<PagedViewModel<Product>>
    {
        public override int PageSize
        {
            get
            {
                if (base.PageSize < 8)
                {
                    base.PageSize = 8;
                }

                return base.PageSize;
            }
        }


        public class ShopFilterPagedQueryHandler : IRequestHandler<ShopFilterPagedQuery, PagedViewModel<Product>>
        {
            private readonly SokaDbContext db;

            public ShopFilterPagedQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }

            public async Task<PagedViewModel<Product>> Handle(ShopFilterPagedQuery request, CancellationToken cancellationToken)
            {
                var query = db.Products
                    .Where(m => m.DeletedDate == null)
                    .OrderByDescending(m => m.Id)
                    .AsQueryable();


                var pagedData = new PagedViewModel<Product>(query, request.PageIndex, request.PageSize);

                return pagedData;

            }
        }
    }
}
