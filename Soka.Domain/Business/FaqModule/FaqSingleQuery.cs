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
    public class FaqSingleQuery :IRequest<Faq>
    {
        public int Id { get; set; }
        public class FaqSingleQueryHandler : IRequestHandler<FaqSingleQuery, Faq>
        {
            private readonly SokaDbContext db;

            public FaqSingleQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<Faq> Handle(FaqSingleQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.Faqs.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);
                    return entity;
            }
        }
    }
}
