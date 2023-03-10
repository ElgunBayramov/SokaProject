using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soka.Domain.Models.Entities;

namespace Soka.Domain.Models.DataContexts.Configurations
{
    public class BasketEntityTypeConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            //builder.HasKey(k => new
            //{
            //    k.ProductId,
            //    k.CreatedByUserId
            //});

            builder.Property(m => m.Id)
                .UseIdentityColumn();


            builder.ToTable("Basket");
        }
    }
}
