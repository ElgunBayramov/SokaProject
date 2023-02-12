using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soka.WebUI.Models.Entities;

namespace Soka.WebUI.Models.DataContexts.Configurations
{
    public class ContactPostEntityTypeConfiguration : IEntityTypeConfiguration<ContactPost>
    {
        public void Configure(EntityTypeBuilder<ContactPost> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired();
            builder.Property(t => t.Email)
                .IsRequired();
            builder.Property(t => t.Subject)
                .IsRequired();
            builder.Property(t => t.Message)
                .IsRequired();
        }
    }
}
