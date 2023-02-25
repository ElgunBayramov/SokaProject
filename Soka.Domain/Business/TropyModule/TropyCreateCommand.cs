using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Soka.Application.AppCode.Extensions;
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
    public class TropyCreateCommand : IRequest<Tropy>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public IFormFile Image { get; set; }

        public class TropyCreateCommandHandler : IRequestHandler<TropyCreateCommand, Tropy>
        {
            private readonly SokaDbContext db;
            private readonly IHostEnvironment env;

            public TropyCreateCommandHandler(SokaDbContext db, IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }
            public async Task<Tropy> Handle(TropyCreateCommand request, CancellationToken cancellationToken)
            {
                var tropy = new Tropy();
                tropy.Title = request.Title;
                tropy.Body = request.Body;
                tropy.ImagePath = request.Image.GetRandomImagePath("tropy");

                await env.SaveAsync(request.Image, tropy.ImagePath, cancellationToken);

                await db.Trophies.AddAsync(tropy, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return tropy;


            }
        }
    }
}
