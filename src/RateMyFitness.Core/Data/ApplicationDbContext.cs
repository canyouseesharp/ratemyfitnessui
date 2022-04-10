using Microsoft.EntityFrameworkCore;
using RateMyFitness.Core.Models;

namespace RateMyFitness.Core.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<GenderType> GenderTypes { get; set; } = default!;
        public DbSet<Rating> Ratings { get; set; } = default!;
        public DbSet<JumpStandard> JumpStandards { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }

    /// <summary>
    /// Create an ApplicationDbContext instance based on the connection string and migration assembly location.
    /// This allows an instance to be created based on the environment we are in.
    /// </summary>
    public class ApplicationDbContextDesignFactory : DesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContextDesignFactory() : base("DefaultConnection", "RateMyFitness.Core")
        { }

        protected override ApplicationDbContext CreateNewInstance(DbContextOptions<ApplicationDbContext> options)
        {
            return new ApplicationDbContext(options);
        }
    }
}

