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

namespace Soka.Domain.Business.ResultModule
{
    public class ResultCreateCommand : IRequest<Result>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ClubName { get; set; }
        public string RivalClubName { get; set; }
        public IFormFile Image { get; set; }

        public class ResultCreateCommandHandler : IRequestHandler<ResultCreateCommand, Result>
        {
            private readonly SokaDbContext db;
            private readonly IHostEnvironment env;

            public ResultCreateCommandHandler(SokaDbContext db, IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }
            public async Task<Result> Handle(ResultCreateCommand request, CancellationToken cancellationToken)
            {
                var result = new Result();
                result.Title = request.Title;
                result.Body = request.Body;
                result.ClubName = request.ClubName;
                result.RivalClubName = request.RivalClubName;
                result.ImagePath = request.Image.GetRandomImagePath("result");
                result.RivalImagePath = request.Image.GetRandomImagePath("result");

                await env.SaveAsync(request.Image, result.ImagePath, cancellationToken);
                await env.SaveAsync(request.Image, result.RivalImagePath, cancellationToken);


                await db.Results.AddAsync(result, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return result;


            }
        }
    }
}
