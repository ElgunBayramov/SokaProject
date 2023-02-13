using MediatR;
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
    public class FaqCreateCommand : IRequest<Faq>
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public class FaqCreateCommandHandler : IRequestHandler<FaqCreateCommand, Faq>
        {
            private readonly SokaDbContext db;

            public FaqCreateCommandHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<Faq> Handle(FaqCreateCommand request, CancellationToken cancellationToken)
            {
                var faq = new Faq() {
                    Question=request.Question,
                   Answer = request.Answer
                };
                await db.Faqs.AddAsync(faq, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return faq;

            }
        }
    }
}
