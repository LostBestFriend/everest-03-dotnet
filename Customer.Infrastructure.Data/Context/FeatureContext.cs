using Customer.DomainModels.Models;
using Customer.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure.Data.Context
{
    public class FeatureContext : DbContext
    {
        public DbSet<CustomersModel> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerMapping).Assembly);
        }

        public FeatureContext(DbContextOptions<FeatureContext> options) : base(options)
        {
        }
    }
}
