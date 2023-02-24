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
    public class TropySingleQuery : IRequest<Tropy>
    {
        public int Id { get; set; }
        public class TropySingleQueryHandler : IRequestHandler<TropySingleQuery, Tropy>
        {
            private readonly SokaDbContext db;

            public TropySingleQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<Tropy> Handle(TropySingleQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.Trophies.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);
                return entity;
            }
        }
    }
}
