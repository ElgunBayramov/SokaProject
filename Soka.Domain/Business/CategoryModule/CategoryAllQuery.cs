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

namespace Soka.Domain.Business.BlogPostModule
{
    public class CategoryAllQuery : IRequest<List<Category>>
    {
        public class CategoryAllQueryHandler : IRequestHandler<CategoryAllQuery, List<Category>>
        {
            private readonly SokaDbContext db;

            public CategoryAllQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Category>> Handle(CategoryAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Categories.Where(m => m.DeletedDate == null)
                    .ToListAsync(cancellationToken);
                return data;
            }
        }
    }
}
