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
    public class BlogPostEntityTypeConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.Property(t => t.Title)
                .IsRequired();
            builder.Property(t => t.Slug)
                .IsRequired();
            builder.HasIndex(t => t.Slug)
                .IsUnique();
            builder.Property(t => t.Body)
                .IsRequired();
            builder.Property(t => t.ImagePath)
                .IsRequired();
        }
    }
}
