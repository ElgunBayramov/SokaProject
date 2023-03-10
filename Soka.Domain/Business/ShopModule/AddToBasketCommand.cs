using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Soka.Application.AppCode.Infrastructure;
using Soka.Domain.AppCode.Extensions;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.ShopModule
{
    public class AddToBasketCommand : IRequest<JsonResponse>
    {
        public int ProductId { get; set; }

        public class AddToBasketCommandHandler : IRequestHandler<AddToBasketCommand, JsonResponse>
        {
            private readonly SokaDbContext db;
            private readonly IActionContextAccessor ctx;

            public AddToBasketCommandHandler(SokaDbContext db, IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }

            public async Task<JsonResponse> Handle(AddToBasketCommand request, CancellationToken cancellationToken)
            {
                var userId = ctx.GetUserId();

                var basket = await db.Baskets.FirstOrDefaultAsync(m => m.ProductId == request.ProductId
                && m.CreatedByUserId == userId, cancellationToken);

                if (basket != null)
                {
                    return new JsonResponse
                    {
                        Error = true,
                        Message = "Məhsul artıq sizin səbətdə mövcuddur"
                    };
                }


                basket = new Basket
                {
                    ProductId = request.ProductId,
                    CreatedByUserId = userId.Value,
                    Quantity = 1
                };

                await db.AddAsync(basket, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);

                return new JsonResponse
                {
                    Error = false,
                    Message = "Səbətə əlavə edildi"
                };
            }
        }
    }
}
