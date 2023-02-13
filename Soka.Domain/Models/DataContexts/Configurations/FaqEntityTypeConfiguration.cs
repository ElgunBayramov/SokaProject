using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soka.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soka.Domain.Models.DataContexts.Configurations
{
    public class FaqEntityTypeConfiguration : IEntityTypeConfiguration<Faq>
    {
        public void Configure(EntityTypeBuilder<Faq> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(K => K.Id)
                .UseIdentityColumn();
            builder.Property(t => t.Question)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(t => t.Answer)
                .IsRequired();   
            builder.ToTable("Faqs");
        }
    }
}
