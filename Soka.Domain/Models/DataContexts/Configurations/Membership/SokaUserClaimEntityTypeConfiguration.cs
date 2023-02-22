using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soka.Domain.Models.Entities.Membership;
using System;


namespace Soka.Domain.Models.DataContexts.Configurations.Membership
{
    public class SokaUserClaimEntityTypeConfiguration : IEntityTypeConfiguration<SokaUserClaim>
    {
        public void Configure(EntityTypeBuilder<SokaUserClaim> builder)
        {
            builder.ToTable("UserClaims", "Membership");
        }
    }
}

