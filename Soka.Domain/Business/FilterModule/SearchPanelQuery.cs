using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Soka.Domain.AppCode.Infrastructure;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.FilterModule
{
    public class SearchPanelQuery : IRequest<SearchPanelModel>
    {


        public class SearchPanelQueryHandler : IRequestHandler<SearchPanelQuery, SearchPanelModel>
        {
            private readonly SokaDbContext db;
            private readonly IMapper mapper;

            public SearchPanelQueryHandler(SokaDbContext db, IMapper mapper)
            {
                this.db = db;
                this.mapper = mapper;
            }

            public async Task<SearchPanelModel> Handle(SearchPanelQuery request, CancellationToken cancellationToken)
            {
                var response = new SearchPanelModel();

                //response.Brands = await db.Products.Include(m => m.Brand)
                //    .Select(m => m.Brand)
                //    .Distinct()
                //    .ToArrayAsync(cancellationToken);

                response.Brands = mapper.Map<HolderChooseModel[]>(await db.Products.Include(m => m.Brand)
                .Select(m => m.Brand)
                .Distinct()
                .ToArrayAsync(cancellationToken));

                response.Sizes = mapper.Map<HolderChooseModel[]>(await db.ProductCatalog
                    .Include(m => m.Size)
                    .Select(m => m.Size)
                    .Distinct()
                    .ToArrayAsync(cancellationToken));

                response.Colors = mapper.Map<HolderChooseModel[]>(await db.ProductCatalog
                    .Include(m => m.Color)
                    .Select(m => m.Color)
                    .Distinct()
                    .ToArrayAsync(cancellationToken));

                response.Types = mapper.Map<HolderChooseModel[]>(await db.ProductCatalog
                    .Include(m => m.Type)
                    .Select(m => m.Type)
                    .Distinct()
                    .ToArrayAsync(cancellationToken));


                var priceRange = await db.ProductCatalog
                    .Include(m => m.Product)
                    .Select(m => new { GroupId = 1, Price = m.Product.Price })
                    .GroupBy(m => m.GroupId)
                    .Select(m => new { Min = m.Min(m => m.Price), Max = m.Max(m => m.Price) })
                    .FirstOrDefaultAsync(cancellationToken);


                //5.0
                response.MinPrice = (int)Math.Floor(priceRange.Min ?? 0);
                response.MaxPrice = (int)Math.Ceiling(priceRange.Max ?? 0);


                return response;

            }
        }
    }
}
