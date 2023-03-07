using MediatR;
using Microsoft.EntityFrameworkCore;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.ProductTypeModule
{
    public class ProductTypesAllQuery : IRequest<List<ProductType>>
    {
        public class ProductTypesAllQueryHandler : IRequestHandler<ProductTypesAllQuery, List<ProductType>>
        {
            private readonly SokaDbContext db;

            public ProductTypesAllQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<ProductType>> Handle(ProductTypesAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Types.Where(m => m.DeletedDate == null)
                    .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
