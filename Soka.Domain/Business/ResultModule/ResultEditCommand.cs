using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

namespace Soka.Domain.Business.ResultModule
{
    public class ResultEditCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ClubName { get; set; }
        public string RivalClubName { get; set; }
        public string ImagePath { get; set; }
        public string RivalImagePath { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile Image2 { get; set; }

        public class ResultEditCommandHandler : IRequestHandler<ResultEditCommand, Result>
        {
            private readonly SokaDbContext db;
            private readonly IHostEnvironment env;

            public ResultEditCommandHandler(SokaDbContext db, IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }
            public async Task<Result> Handle(ResultEditCommand request, CancellationToken cancellationToken)
            {
                var model = await db.Results
                    .FirstOrDefaultAsync(b => b.Id == request.Id && b.DeletedDate == null, cancellationToken);
                if (model == null)
                {
                    return null;
                }
                model.Title = request.Title;
                model.Body = request.Body;
                model.ClubName = request.ClubName;
                model.RivalClubName = request.RivalClubName;    

                if (request.Image == null)
                {

                    goto save;
                }
                string newImageName = request.Image.GetRandomImagePath("result");
                await env.SaveAsync(request.Image, newImageName, cancellationToken);
                env.ArchiveImage(model.ImagePath);
                model.ImagePath = newImageName;
                if(request.Image2 == null)
                {

                    goto save;
                }

                string newImageName2 = request.Image2.GetRandomImagePath("result");
                await env.SaveAsync(request.Image2, newImageName2, cancellationToken);
                env.ArchiveImage(model.RivalImagePath);
                model.RivalImagePath = newImageName2;


            save:
                await db.SaveChangesAsync(cancellationToken);
                return model;


            }
        }
    }
}
