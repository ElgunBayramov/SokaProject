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

namespace Soka.Domain.Business.ProductModule
{
    public class ProductEditCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }

        public class ProductEditCommandHandler : IRequestHandler<ProductEditCommand, Product>
        {
            private readonly SokaDbContext db;
            private readonly IHostEnvironment env;

            public ProductEditCommandHandler(SokaDbContext db,IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }
            public async Task<Product> Handle(ProductEditCommand request, CancellationToken cancellationToken)
            {
                var model = await db.Products
                    .FirstOrDefaultAsync(b => b.Id == request.Id && b.DeletedDate == null, cancellationToken);
                if (model == null)
                {
                    return null;
                }
                model.Name = request.Name;
                model.ShortDescription = request.ShortDescription;
                model.Description = request.Description;
                model.BrandId = request.BrandId;
                model.CategoryId = request.CategoryId;

                if (request.Image == null)
                {

                    goto save;
                }
                string newImageName = request.Image.GetRandomImagePath("product");
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
