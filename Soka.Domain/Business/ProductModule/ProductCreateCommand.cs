using MediatR;
using Microsoft.AspNetCore.Http;
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

namespace Soka.Domain.Business.ProductModule
{
    public class ProductCreateCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public IFormFile Image { get; set; }

        public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
        {
            private readonly SokaDbContext db;
            private readonly IHostEnvironment env;

            public ProductCreateCommandHandler(SokaDbContext db,IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }
            public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
            {
                var product = new Product();
                product.Name = request.Name;
                product.ShortDescription = request.ShortDescription;
                product.Description = request.Description;
                product.Slug = request.Name.ToSlug();
                product.BrandId = request.BrandId;
                product.CategoryId = request.CategoryId;
                product.ImagePath = request.Image.GetRandomImagePath("product");

                await env.SaveAsync(request.Image, product.ImagePath, cancellationToken);

                await db.Products.AddAsync(product,cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return product;


            }
        }
    }
}
