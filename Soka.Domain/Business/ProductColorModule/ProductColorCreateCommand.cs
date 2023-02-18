using MediatR;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.ProductColorModule
{
    public class ProductColorCreateCommand : IRequest<ProductColor>
    {
        public string Name { get; set; }
        public class ProductColorCreateCommandHandler : IRequestHandler<ProductColorCreateCommand, ProductColor>
        {
            private readonly SokaDbContext db;

            public ProductColorCreateCommandHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<ProductColor> Handle(ProductColorCreateCommand request, CancellationToken cancellationToken)
            {
                var ProductColor = new ProductColor()
                {
                    Name = request.Name,
                };

                await db.Colors.AddAsync(ProductColor, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return ProductColor;
            }
        }
    }
}
