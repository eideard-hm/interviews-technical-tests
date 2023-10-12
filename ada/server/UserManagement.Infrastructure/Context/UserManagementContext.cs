using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Configs;

namespace UserManagement.Infrastructure.Context
{
    public class UserManagementContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = GetAppSettingsConfig();
                optionsBuilder.UseSqlServer(connectionString);
                optionsBuilder.LogTo(Console.WriteLine);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // add custom configuration
            builder.ApplyConfiguration(new UserConfig());
        }

        private static string GetAppSettingsConfig()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "../UserManagement.Api");
            // Build config
            IConfiguration config = new ConfigurationBuilder()
                                        .SetBasePath(path)
                                        .AddJsonFile("appsettings.json")
                                        .Build();

            var connectionString = config.GetConnectionString("UserManagementConnection");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Could not find connection string named 'UserManagementConnection'");
            }
            return connectionString;
        }
    }
}
