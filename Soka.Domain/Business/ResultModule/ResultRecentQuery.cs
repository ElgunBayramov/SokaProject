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

namespace Soka.Domain.Business.ResultModule
{
    public class ResultRecentQuery : IRequest<List<Result>>
    {
        public int Size { get; set; }
        public class ResultRecentQueryHandler : IRequestHandler<ResultRecentQuery, List<Result>>
        {
            private readonly SokaDbContext db;

            public ResultRecentQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Result>> Handle(ResultRecentQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Results
                    .Where(m => m.DeletedDate == null)
                    .OrderByDescending(m => m.GameDate)
                    .Take(request.Size < 2 ? 2 : request.Size)
                    .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
