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
    public class FaqEditCommand : IRequest<Faq>
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public class FaqEditCommandHandler : IRequestHandler<FaqEditCommand, Faq>
        {
            private readonly SokaDbContext db;

            public FaqEditCommandHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<Faq> Handle(FaqEditCommand request, CancellationToken cancellationToken)
            {
                var faq = await db.Faqs.FirstOrDefaultAsync(b => b.Id == request.Id && b.DeletedDate == null, cancellationToken);
                if(faq == null)
                {
                    return null;
                }
                faq.Question = request.Question;
                faq.Answer = request.Answer;
                await db.SaveChangesAsync(cancellationToken);
                return faq;
            }
        }
    }
}
