using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soka.Domain.Models.Entities.Membership;
using System;


namespace Soka.Domain.Models.DataContexts.Configurations.Membership
{
    public class SokaUserRoleEntityTypeConfiguration : IEntityTypeConfiguration<SokaUserRole>
    {
        public void Configure(EntityTypeBuilder<SokaUserRole> builder)
        {
            builder.HasKey(k => new
            {
                k.UserId,
                k.RoleId
            });
            builder.ToTable("UserRoles", "Membership");
        }
    }
}

