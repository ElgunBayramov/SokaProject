using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soka.Domain.Models.Entities;

namespace Soka.Domain.Models.DataContexts.Configurations
{
    internal class ProductCatalogItemEntityTypeConfiguration : IEntityTypeConfiguration<ProductCatalogItem>
    {
        public void Configure(EntityTypeBuilder<ProductCatalogItem> builder)
        {
            //composite primary key
            builder.HasKey(k => new
            {
                k.ProductId,
                k.ColorId,
                k.SizeId,
                k.TypeId
            });

            builder.Property(m => m.Id)
                .UseIdentityColumn();

            builder.ToTable("ProductCatalog");
        }
    }
}
