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
    public class ProductColorSingleQuery : IRequest<ProductColor>
    {
        public int Id { get; set; }
        public class ProductColorSingleQueryHandler : IRequestHandler<ProductColorSingleQuery, ProductColor>
        {
            private readonly SokaDbContext db;

            public ProductColorSingleQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<ProductColor> Handle(ProductColorSingleQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.Colors.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);
                return entity;
            }
        }
    }
}
