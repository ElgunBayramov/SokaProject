using MediatR;
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
    public class LeagueCreateCommand : IRequest<League>
    {
        public string Body { get; set; }
        public string Venue { get; set; }
        public class LeagueCreateCommandHandler : IRequestHandler<LeagueCreateCommand, League>
        {
            private readonly SokaDbContext db;

            public LeagueCreateCommandHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<League> Handle(LeagueCreateCommand request, CancellationToken cancellationToken)
            {
                var League = new League()
                {
                    Body = request.Body,
                    Venue = request.Venue
                };
                await db.Leagues.AddAsync(League, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return League;

            }
        }
    }
}
