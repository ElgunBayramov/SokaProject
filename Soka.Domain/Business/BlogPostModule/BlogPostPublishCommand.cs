﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Soka.Application.AppCode.Infrastructure;
using Soka.Domain.Models.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.BlogPostModule
{
    public class BlogPostPublishCommand : IRequest<JsonResponse>
    {
        public int Id { get; set; }
        public class BlogPostPublishCommandHandler : IRequestHandler<BlogPostPublishCommand, JsonResponse>
        {
            private readonly SokaDbContext db;

            public BlogPostPublishCommandHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<JsonResponse> Handle(BlogPostPublishCommand request, CancellationToken cancellationToken)
            {
                var post = await db.BlogPosts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if(post == null)
                {
                    return new JsonResponse{
                        Error = true,
                        Message = "Bu post movcud deyil"
                       };
                }
                else if(post.DeletedDate != null)
                {
                    return new JsonResponse{
                        Error = true,
                        Message = "Bu post silindiyi ucun derc edile bilmez!"
                    };
                }
                else if (post.PublishDate != null)
                {
                    return new JsonResponse
                    {
                        Error = true,
                        Message = "Bu post artiq derc edilib!"
                    };
                }
                post.PublishDate = DateTime.Now;
                await db.SaveChangesAsync(cancellationToken);

                return new JsonResponse
                {
                    Error = false,
                    Message = "Bu post derc edildi!"
                };
            }
        }
    }
}
