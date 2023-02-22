using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soka.Domain.Models.Entities.Membership;
using System;


namespace Soka.Domain.Models.DataContexts.Configurations.Membership
{
    public class SokaUserLoginEntityTypeConfiguration : IEntityTypeConfiguration<SokaUserLogin>
    {
        public void Configure(EntityTypeBuilder<SokaUserLogin> builder)
        {
            builder.ToTable("UserLogins", "Membership");
        }
    }
}

