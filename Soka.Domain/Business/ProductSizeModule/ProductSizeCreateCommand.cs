using MediatR;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.ProductSizeModule
{
    public class ProductSizeCreateCommand : IRequest<ProductSize>
    {
        public string Name { get; set; }
        public class ProductSizeCreateCommandHandler : IRequestHandler<ProductSizeCreateCommand, ProductSize>
        {
            private readonly SokaDbContext db;

            public ProductSizeCreateCommandHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<ProductSize> Handle(ProductSizeCreateCommand request, CancellationToken cancellationToken)
            {
                var ProductSize = new ProductSize()
                {
                    Name = request.Name,
                };

                await db.Sizes.AddAsync(ProductSize, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return ProductSize;
            }
        }
    }
}
