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
    public class LeagueEditCommand : IRequest<League>
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string Venue { get; set; }
        public class LeagueEditCommandHandler : IRequestHandler<LeagueEditCommand, League>
        {
            private readonly SokaDbContext db;

            public LeagueEditCommandHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<League> Handle(LeagueEditCommand request, CancellationToken cancellationToken)
            {
                var League = await db.Leagues.FirstOrDefaultAsync(b => b.Id == request.Id && b.DeletedDate == null, cancellationToken);
                if (League == null)
                {
                    return null;
                }
                League.Body = request.Body;
                League.Venue = request.Venue;
                await db.SaveChangesAsync(cancellationToken);
                return League;
            }
        }
    }
}
