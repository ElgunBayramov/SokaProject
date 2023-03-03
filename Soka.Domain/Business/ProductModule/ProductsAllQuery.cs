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

namespace Soka.Domain.Business.ProductModule
{
    public class ProductsAllQuery : IRequest<List<Product>>
    {
        public class ProductsAllQueryHandler : IRequestHandler<ProductsAllQuery, List<Product>>
        {
            private readonly SokaDbContext db;

            public ProductsAllQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Product>> Handle(ProductsAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Products
                    .Where(m => m.DeletedDate == null)
                    .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
