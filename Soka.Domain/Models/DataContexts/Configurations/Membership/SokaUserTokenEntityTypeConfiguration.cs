using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soka.Domain.Models.Entities.Membership;
using System;


namespace Soka.Domain.Models.DataContexts.Configurations.Membership
{
    public class SokaUserTokenEntityTypeConfiguration : IEntityTypeConfiguration<SokaUserToken>
    {
        public void Configure(EntityTypeBuilder<SokaUserToken> builder)
        {
            builder.ToTable("UserTokens", "Membership");
        }
    }
}

