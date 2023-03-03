using MediatR;
using Microsoft.EntityFrameworkCore;
using Soka.Application.AppCode.Infrastructure;
using Soka.Domain.Models.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.ProductModule
{
    public class ProductRemoveCommand : IRequest<JsonResponse>
    {
        public int Id { get; set; }
        public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, JsonResponse>
        {
            private readonly SokaDbContext db;

            public ProductRemoveCommandHandler(SokaDbContext db)
            {
                this.db = db;
            }

            public async Task<JsonResponse> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.Products
               .FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);


                if (entity == null)
                {
                    return new JsonResponse
                    {
                        Error = true,
                        Message = "Qeyd tapilmadi"
                    };
                }

                entity.DeletedDate = DateTime.UtcNow.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);

                return new JsonResponse
                {
                    Error = false,
                    Message = "Ugurludur"
                };
            }
        }
    }
}
