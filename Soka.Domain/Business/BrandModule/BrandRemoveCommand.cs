using MediatR;
using Microsoft.EntityFrameworkCore;
using Soka.Domain.AppCode.Infrastructure;
using Soka.Domain.Models.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.BrandModule
{
    public class BrandRemoveCommand : IRequest<JsonResponse>
    {
        public int Id { get; set; }
        public class BrandRemoveCommandHandler : IRequestHandler<BrandRemoveCommand, JsonResponse>
        {
            private readonly SokaDbContext db;

            public BrandRemoveCommandHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<JsonResponse> Handle(BrandRemoveCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.Brands.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null);
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
