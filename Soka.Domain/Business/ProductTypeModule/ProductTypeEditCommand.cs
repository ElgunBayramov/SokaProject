using MediatR;
using Microsoft.EntityFrameworkCore;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.ProductTypeModule
{
    public class ProductTypeEditCommand : IRequest<ProductType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class ProductTypeEditCommandHandler : IRequestHandler<ProductTypeEditCommand, ProductType>
        {
            private readonly SokaDbContext db;

            public ProductTypeEditCommandHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<ProductType> Handle(ProductTypeEditCommand request, CancellationToken cancellationToken)
            {
                var productType = await db.Types.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null,cancellationToken);
                if(productType == null)
                {
                    return null;
                }
                productType.Name = request.Name;
                await db.SaveChangesAsync(cancellationToken);
                return productType;   
            }
        }
    }
}
