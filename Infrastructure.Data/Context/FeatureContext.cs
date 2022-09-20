using Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class FeatureContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerMapping).Assembly);
        }

        public FeatureContext(DbContextOptions<FeatureContext> options) : base(options)
        {
        }
    }
}
