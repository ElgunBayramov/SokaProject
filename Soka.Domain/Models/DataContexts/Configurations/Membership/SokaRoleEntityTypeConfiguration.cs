using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soka.Domain.Models.Entities.Membership;
using System;


namespace Soka.Domain.Models.DataContexts.Configurations.Membership
{
    public class SokaRoleEntityTypeConfiguration : IEntityTypeConfiguration<SokaRole>
    {
        public void Configure(EntityTypeBuilder<SokaRole> builder)
        {
            builder.ToTable("Roles", "Membership");
        }
    }
}

