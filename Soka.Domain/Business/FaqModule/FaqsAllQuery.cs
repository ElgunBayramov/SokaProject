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

namespace Soka.Domain.Business.FaqModule
{
    public class FaqsAllQuery : IRequest<List<Faq>>
    {
        public class FaqsAllQueryHandler : IRequestHandler<FaqsAllQuery, List<Faq>>
        {
            private readonly SokaDbContext db;

            public FaqsAllQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<List<Faq>> Handle(FaqsAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Faqs
                    .Where(m => m.DeletedDate == null)
                    .ToListAsync(cancellationToken);
                return data;
            }
        }
    }
}
