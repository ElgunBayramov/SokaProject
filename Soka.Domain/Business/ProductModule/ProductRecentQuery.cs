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
    public class ProductRecentQuery : IRequest<List<Product>>
    {
        public int Size { get; set; }
        public class ProductRecentQueryHandler : IRequestHandler<ProductRecentQuery, List<Product>>
        {
            private readonly SokaDbContext db;

            public ProductRecentQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Product>> Handle(ProductRecentQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Products
                    .Where(m => m.DeletedDate == null)
                    .OrderByDescending(m => m.Id)
                    .Take(request.Size < 2 ? 2 : request.Size)
                    .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
