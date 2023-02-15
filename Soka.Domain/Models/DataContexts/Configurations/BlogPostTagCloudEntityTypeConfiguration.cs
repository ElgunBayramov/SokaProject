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
    public class BlogPostTagCloudEntityTypeConfiguration : IEntityTypeConfiguration<BlogPostTagCloud>
    {
        public void Configure(EntityTypeBuilder<BlogPostTagCloud> builder)
        {
            builder.HasKey(k => new
            {
                k.BlogPostId,
                k.TagId
            });
            builder.ToTable("BlogPostTagCloud");
        }
    }
}
