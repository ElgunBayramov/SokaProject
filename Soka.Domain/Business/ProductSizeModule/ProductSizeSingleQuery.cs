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
    public class ProductSizeSingleQuery : IRequest<ProductSize>
    {
        public int Id { get; set; }
        public class ProductSizeSingleQueryHandler : IRequestHandler<ProductSizeSingleQuery, ProductSize>
        {
            private readonly SokaDbContext db;

            public ProductSizeSingleQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<ProductSize> Handle(ProductSizeSingleQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.Sizes.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);
                return entity;
            }
        }
    }
}
