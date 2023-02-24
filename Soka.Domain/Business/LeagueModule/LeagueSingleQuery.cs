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
    public class LeagueSingleQuery : IRequest<League>
    {
        public int Id { get; set; }
        public class LeagueSingleQueryHandler : IRequestHandler<LeagueSingleQuery, League>
        {
            private readonly SokaDbContext db;

            public LeagueSingleQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<League> Handle(LeagueSingleQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.Leagues.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);
                return entity;
            }
        }
    }
}
