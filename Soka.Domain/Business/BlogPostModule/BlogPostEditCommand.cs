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

namespace Soka.Domain.Business.BlogPostModule
{
    public class BlogPostEditCommand : IRequest<BlogPost>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
        public int[] TagIds { get; set; }
        public class BlogPostEditCommandHandler : IRequestHandler<BlogPostEditCommand, BlogPost>
        {
            private readonly SokaDbContext db;
            private readonly IHostEnvironment env;

            public BlogPostEditCommandHandler(SokaDbContext db, IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }
            public async Task<BlogPost> Handle(BlogPostEditCommand request, CancellationToken cancellationToken)
            {
                var model = await db.BlogPosts
                    .Include(bp => bp.TagCloud)
                    .FirstOrDefaultAsync(b => b.Id==request.Id && b.DeletedDate==null,cancellationToken);
                if (model == null)
                {
                    return null;    
                }
                model.Title = request.Title;
                model.Body = request.Body;
                model.CategoryId = request.CategoryId;

                if (request.Image == null)
                    goto save;

                string newImageName = request.Image.GetRandomImagePath("blog");

                await env.SaveAsync(request.Image, newImageName, cancellationToken);
                env.ArchiveImage(model.ImagePath);
                model.ImagePath = newImageName;

            save:
                if (request.TagIds == null)
                    request.TagIds = new int[] { };

                #region Formdan gelen elave taglari tapib insert etmek

                int[] forInsert = request.TagIds.Except(model.TagCloud.Select(tc => tc.TagId))
                    .ToArray();

                foreach(var item in forInsert)
                {
                    var tc = new BlogPostTagCloud();
                    tc.TagId = item;
                    tc.BlogPostId = model.Id;
                    db.BlogPostTagCloud.Add(tc);
                }

                #endregion

                #region Databasede olub formdan gelmeyen taglari tapib silmek

                int[] forDelete = model.TagCloud.Select(tc => tc.TagId).Except(request.TagIds).ToArray();



                foreach (var item in forDelete)
                {
                    var tc = await db.BlogPostTagCloud.FirstOrDefaultAsync(bptc => bptc.TagId == item && bptc.BlogPostId == model.Id, cancellationToken);

                    db.BlogPostTagCloud.Remove(tc);

                }


                #endregion
                await db.SaveChangesAsync(cancellationToken);
                return model;
            }
        }
    }
}
