using IdeaManager.Core.Entities;
using IdeaManager.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace IdeaManager.Data.Db
{
    public class IdeaDbContext : DbContext
    {
        public IdeaDbContext(DbContextOptions<IdeaDbContext> options) : base(options) { }

        public DbSet<Idea> Ideas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IdeaConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new VoteConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}


