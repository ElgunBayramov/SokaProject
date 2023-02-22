using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soka.Domain.Models.Entities.Membership;
using System;


namespace Soka.Domain.Models.DataContexts.Configurations.Membership
{
    public class SokaRoleClaimEntityTypeConfiguration : IEntityTypeConfiguration<SokaRoleClaim>
    {
        public void Configure(EntityTypeBuilder<SokaRoleClaim> builder)
        {
            builder.ToTable("RoleClaims", "Membership");
        }
    }
}

