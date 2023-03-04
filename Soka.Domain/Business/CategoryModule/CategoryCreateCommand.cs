using MediatR;
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
    public class CategoryCreateCommand : IRequest<Category>
    {
        public string Name { get; set; }
        public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, Category>
        {
            private readonly SokaDbContext db;

            public CategoryCreateCommandHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<Category> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
            {
                var Category = new Category()
                {
                    Name = request.Name
                };
                await db.Categories.AddAsync(Category, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return Category;

            }
        }
    }
}
