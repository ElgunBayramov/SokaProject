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

namespace Soka.Domain.Business.ProductColorModule
{
    public class ProductColorEditCommand : IRequest<ProductColor>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class ProductColorEditCommandHandler : IRequestHandler<ProductColorEditCommand, ProductColor>
        {
            private readonly SokaDbContext db;

            public ProductColorEditCommandHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<ProductColor> Handle(ProductColorEditCommand request, CancellationToken cancellationToken)
            {
                var ProductColor = await db.Colors.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null,cancellationToken);
                if(ProductColor == null)
                {
                    return null;
                }
                ProductColor.Name = request.Name;
                await db.SaveChangesAsync(cancellationToken);
                return ProductColor;   
            }
        }
    }
}
