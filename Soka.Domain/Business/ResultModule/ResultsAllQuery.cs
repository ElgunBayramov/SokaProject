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
    public class ResultsAllQuery : IRequest<List<Result>>
    {
        public class ResultsAllQueryHandler : IRequestHandler<ResultsAllQuery, List<Result>>
        {
            private readonly SokaDbContext db;

            public ResultsAllQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Result>> Handle(ResultsAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Results
                    .Where(m => m.DeletedDate == null)
                    .ToListAsync(cancellationToken);
                return data;
            }
        }
    }
}
