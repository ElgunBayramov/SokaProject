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

namespace Soka.Domain.Business.ProductColorModule
{
    public class ProductColorsAllQuery : IRequest<List<ProductColor>>
    {
        public class ProductColorsAllQueryHandler : IRequestHandler<ProductColorsAllQuery, List<ProductColor>>
        {
            private readonly SokaDbContext db;

            public ProductColorsAllQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<ProductColor>> Handle(ProductColorsAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Colors.Where(m => m.DeletedDate == null)
                    .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
