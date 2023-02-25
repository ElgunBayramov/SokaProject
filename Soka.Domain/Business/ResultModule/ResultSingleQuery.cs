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
    public class ResultSingleQuery : IRequest<Result>
    {
        public int Id { get; set; }
        public class ResultSingleQueryHandler : IRequestHandler<ResultSingleQuery, Result>
        {
            private readonly SokaDbContext db;

            public ResultSingleQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<Result> Handle(ResultSingleQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.Results.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);
                return entity;
            }
        }
    }
}
