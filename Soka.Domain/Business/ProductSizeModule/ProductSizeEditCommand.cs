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

namespace Soka.Domain.Business.ProductSizeModule
{
    public class ProductSizeEditCommand : IRequest<ProductSize>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class ProductSizeEditCommandHandler : IRequestHandler<ProductSizeEditCommand, ProductSize>
        {
            private readonly SokaDbContext db;

            public ProductSizeEditCommandHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<ProductSize> Handle(ProductSizeEditCommand request, CancellationToken cancellationToken)
            {
                var ProductSize = await db.Sizes.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null,cancellationToken);
                if(ProductSize == null)
                {
                    return null;
                }
                ProductSize.Name = request.Name;
                await db.SaveChangesAsync(cancellationToken);
                return ProductSize;   
            }
        }
    }
}
