using Microsoft.EntityFrameworkCore;
using MiniBank.Entities;

namespace MiniBank.Persistence
{
    public class MiniBankDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public MiniBankDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("MiniBankDbConnection"));
        }
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<CustomerAccount> CustomerAccounts => Set<CustomerAccount>();
        public DbSet<Image> Images => Set<Image>();
    }
}
