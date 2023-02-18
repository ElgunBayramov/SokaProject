using MediatR;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.BrandModule
{
    public class BrandCreateCommand : IRequest<Brand>
    {
        public string Name { get; set; }
        public class BrandCreateCommandHandler : IRequestHandler<BrandCreateCommand, Brand>
        {
            private readonly SokaDbContext db;

            public BrandCreateCommandHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<Brand> Handle(BrandCreateCommand request, CancellationToken cancellationToken)
            {
                var brand = new Brand()
                {
                    Name = request.Name,
                };

                await db.Brands.AddAsync(brand, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return brand;
            }
        }
    }
}
