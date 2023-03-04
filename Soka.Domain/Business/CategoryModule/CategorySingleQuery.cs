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

namespace Soka.Domain.Business.CategoryModule
{
    public class CategorySingleQuery : IRequest<Category>
    {
        public int Id { get; set; }
        public class CategorySingleQueryHandler : IRequestHandler<CategorySingleQuery, Category>
        {
            private readonly SokaDbContext db;

            public CategorySingleQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<Category> Handle(CategorySingleQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.Categories.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);
                return entity;
            }
        }
    }
}
