using MediatR;
using Microsoft.EntityFrameworkCore;
using Soka.Application.AppCode.Services;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.ContactModule
{
    public class ContactAnswerCommand:IRequest<ContactPost>
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public class ContactAnswerCommandHandler : IRequestHandler<ContactAnswerCommand, ContactPost>
        {
            private readonly SokaDbContext sokaDbContext;
            private readonly EmailService emailService;

            public ContactAnswerCommandHandler(SokaDbContext sokaDbContext,EmailService emailService)
            {
                this.sokaDbContext = sokaDbContext;
                this.emailService = emailService;
            }
            public async Task<ContactPost> Handle(ContactAnswerCommand request, CancellationToken cancellationToken)
            {
                var data = await sokaDbContext.ContactPosts.FirstOrDefaultAsync(c => c.Id == request.Id && c.DeletedDate == null, cancellationToken);
                if (data == null)
                {
                    return null;
                }
                data.Answer = request.Answer;
                data.AnsweredDate = DateTime.UtcNow.AddHours(4);
                await emailService.SendEmailAsync(data.Email,"Soka.az", data.Answer);
                await sokaDbContext.SaveChangesAsync(cancellationToken);
                return data;

            }
        }
    }
}
