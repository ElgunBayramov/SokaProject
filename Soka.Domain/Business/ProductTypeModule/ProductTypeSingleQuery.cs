using MediatR;
using Microsoft.EntityFrameworkCore;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.ProductTypeModule
{
    public class ProductTypeSingleQuery : IRequest<ProductType>
    {
        public int Id { get; set; }
        public class ProductTypeSingleQueryHandler : IRequestHandler<ProductTypeSingleQuery, ProductType>
        {
            private readonly SokaDbContext db;

            public ProductTypeSingleQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<ProductType> Handle(ProductTypeSingleQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.Types.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);
                return entity;
            }
        }
    }
}
