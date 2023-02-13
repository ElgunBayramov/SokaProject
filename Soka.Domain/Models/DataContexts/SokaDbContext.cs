
using Microsoft.EntityFrameworkCore;
using Soka.Domain.Models.Entities;

namespace Soka.Domain.Models.DataContexts
{
    public class SokaDbContext : DbContext
    {
        public SokaDbContext(DbContextOptions options)
            : base(options) { }
        public DbSet<ContactPost> ContactPosts { get; set; }
        public DbSet<Subscribe> Subscribers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogPostComment> BlogPostComments { get; set; }
        public DbSet<Faq> Faqs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SokaDbContext).Assembly);
        }
    }
}
