using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Soka.Domain.AppCode.Extensions;
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
    public class TropyEditCommand : IRequest<Tropy>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
        public class TropyEditCommandHandler : IRequestHandler<TropyEditCommand, Tropy>
        {
            private readonly SokaDbContext db;
            private readonly IHostEnvironment env;

            public TropyEditCommandHandler(SokaDbContext db, IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }
            public async Task<Tropy> Handle(TropyEditCommand request, CancellationToken cancellationToken)
            {
                var model = await db.Trophies
                    .FirstOrDefaultAsync(b => b.Id == request.Id && b.DeletedDate == null, cancellationToken);
                if (model == null)
                {
                    return null;
                }
                model.Title = request.Title;
                model.Body = request.Body;

                if (request.Image == null)
                    goto save;
                string newImageName = request.Image.GetRandomImagePath("tropy");
                await env.SaveAsync(request.Image, newImageName, cancellationToken);
                env.ArchiveImage(model.ImagePath);
                model.ImagePath = newImageName;


                save:
                await db.SaveChangesAsync(cancellationToken);
                return model;


            }
        }
    }
}
