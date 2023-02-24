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

namespace Soka.Domain.Business.TropyModule
{
    public class TrophiesAllQuery : IRequest<List<Tropy>>
    {
        public class TrophiesAllQueryHandler : IRequestHandler<TrophiesAllQuery, List<Tropy>>
        {
            private readonly SokaDbContext db;

            public TrophiesAllQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Tropy>> Handle(TrophiesAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Trophies
                    .Where(m => m.DeletedDate == null)
                    .ToListAsync(cancellationToken);
                return data;
            }
        }
    }
}
