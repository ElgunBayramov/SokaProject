using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.ShopModule
{
    public class BasketQuery : IRequest<List<Product>>
    {
        public class BasketQueryHandler : IRequestHandler<BasketQuery, List<Product>>
        {
            private readonly SokaDbContext db;
            private readonly IActionContextAccessor ctx;

            public BasketQueryHandler(SokaDbContext db, IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }

            public async Task<List<Product>> Handle(BasketQuery request, CancellationToken cancellationToken)
            {
                if (ctx.ActionContext.HttpContext.Request.Cookies.TryGetValue("basket", out string basket))
                {
                    //[1,2,3,4]
                    var productIds = JsonConvert.DeserializeObject<int[]>(basket);

                    var products = await db.Products
                    .Where(m => m.ImagePath != "")
                    .Where(m => productIds.Contains(m.Id))
                    .ToListAsync(cancellationToken);
                    return products;
                }

                return null;
            }
        }
    }
}
