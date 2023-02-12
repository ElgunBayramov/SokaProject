
using Microsoft.EntityFrameworkCore;
using Soka.WebUI.Models.Entities;

namespace Soka.WebUI.Models.DataContexts
{
    public class SokaDbContext : DbContext
    {
        public SokaDbContext(DbContextOptions options)
            : base(options) { }
        public DbSet<ContactPost> ContactPosts { get; set; }
        public DbSet<Subscribe> Subscribers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SokaDbContext).Assembly);
        }
    }
}
