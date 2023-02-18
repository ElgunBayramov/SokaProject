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

namespace Soka.Domain.Business.ProductSizeModule
{
    public class ProductSizesAllQuery : IRequest<List<ProductSize>>
    {
        public class ProductSizesAllQueryHandler : IRequestHandler<ProductSizesAllQuery, List<ProductSize>>
        {
            private readonly SokaDbContext db;

            public ProductSizesAllQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<ProductSize>> Handle(ProductSizesAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Sizes.Where(m => m.DeletedDate == null)
                    .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
