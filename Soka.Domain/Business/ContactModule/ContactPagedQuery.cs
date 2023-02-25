using MediatR;
using Microsoft.EntityFrameworkCore;
using Soka.Application.AppCode.Infrastructure;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using Soka.Domain.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.ContactModule
{
    public class ContactPagedQuery : PageableModel, IRequest<PagedViewModel<ContactPost>>
    {
        public override int PageSize
        {
            get
            {
                if (base.PageSize < 5)
                {
                    return 5;
                }

                return base.PageSize;
            }
        }
        public class ContactPagedQueryHandler : IRequestHandler<ContactPagedQuery, PagedViewModel<ContactPost>>
        {
            private readonly SokaDbContext db;

            public ContactPagedQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<PagedViewModel<ContactPost>> Handle(ContactPagedQuery request, CancellationToken cancellationToken)
            {
                var data = db.ContactPosts.Where(c => c.DeletedDate == null && c.AnsweredDate==null)
                .AsQueryable();


                var pagedData = new PagedViewModel<ContactPost>(data, request.PageIndex, request.PageSize);
                return pagedData;
            }
        }
    }
}
