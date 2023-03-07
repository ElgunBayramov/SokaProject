using MediatR;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.ProductTypeModule
{
    public class ProductTypeCreateCommand : IRequest<ProductType>
    {
        public string Name { get; set; }
        public class ProductTypeCreateCommandHandler : IRequestHandler<ProductTypeCreateCommand, ProductType>
        {
            private readonly SokaDbContext db;

            public ProductTypeCreateCommandHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<ProductType> Handle(ProductTypeCreateCommand request, CancellationToken cancellationToken)
            {
                var productType = new ProductType()
                {
                    Name = request.Name,
                };

                await db.Types.AddAsync(productType, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return productType;
            }
        }
    }
}
