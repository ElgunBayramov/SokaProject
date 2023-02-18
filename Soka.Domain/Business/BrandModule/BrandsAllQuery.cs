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

namespace Soka.Domain.Business.BrandModule
{
    public class BrandsAllQuery : IRequest<List<Brand>>
    {
        public class BrandsAllQueryHandler : IRequestHandler<BrandsAllQuery, List<Brand>>
        {
            private readonly SokaDbContext db;

            public BrandsAllQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Brand>> Handle(BrandsAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Brands.Where(m => m.DeletedDate == null)
                    .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
