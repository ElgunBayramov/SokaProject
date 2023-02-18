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

namespace Soka.Domain.Business.BrandModule
{
    public class BrandEditCommand : IRequest<Brand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class BrandEditCommandHandler : IRequestHandler<BrandEditCommand, Brand>
        {
            private readonly SokaDbContext db;

            public BrandEditCommandHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<Brand> Handle(BrandEditCommand request, CancellationToken cancellationToken)
            {
                var brand = await db.Brands.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null,cancellationToken);
                if(brand == null)
                {
                    return null;
                }
                brand.Name = request.Name;
                await db.SaveChangesAsync(cancellationToken);
                return brand;   
            }
        }
    }
}
