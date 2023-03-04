using MediatR;
using Microsoft.EntityFrameworkCore;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.CategoryModule
{
    public class CategoryEditCommand : IRequest<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class CategoryEditCommandHandler : IRequestHandler<CategoryEditCommand, Category>
        {
            private readonly SokaDbContext db;

            public CategoryEditCommandHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<Category> Handle(CategoryEditCommand request, CancellationToken cancellationToken)
            {
                var Category = await db.Categories.FirstOrDefaultAsync(b => b.Id == request.Id && b.DeletedDate == null, cancellationToken);
                if (Category == null)
                {
                    return null;
                }
                Category.Name = request.Name;
                await db.SaveChangesAsync(cancellationToken);
                return Category;
            }
        }
    }
}
