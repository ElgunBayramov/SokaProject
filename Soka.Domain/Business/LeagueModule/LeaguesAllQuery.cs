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

namespace Soka.Domain.Business.LeagueModule
{
    public class LeaguesAllQuery : IRequest<List<League>>
    {
        public class LeaguesAllQueryHandler : IRequestHandler<LeaguesAllQuery, List<League>>
        {
            private readonly SokaDbContext db;

            public LeaguesAllQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<League>> Handle(LeaguesAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Leagues
                    .Where(m => m.DeletedDate == null)
                    .ToListAsync(cancellationToken);
                return data;
            }
        }
    }
}
