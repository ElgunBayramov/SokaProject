using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soka.Domain.Models.Entities.Membership;
using System;


namespace Soka.Domain.Models.DataContexts.Configurations.Membership
{
    public class SokaUserEntityTypeConfiguration : IEntityTypeConfiguration<SokaUser>
    {
        public void Configure(EntityTypeBuilder<SokaUser> builder)
        {
            builder.ToTable("Users", "Membership");
        }
    }
}

