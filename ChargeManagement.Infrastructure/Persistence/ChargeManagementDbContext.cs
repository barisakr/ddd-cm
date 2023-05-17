using ChargeManagement.Domain.Brand; 
using ChargeManagement.Domain.Menu;
using ChargeManagement.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace ChargeManagement.Infrastructure.Persistence
{
    public class ChargeManagementDbContext : DbContext
    {
        public ChargeManagementDbContext(DbContextOptions<ChargeManagementDbContext> options) : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<User> Users { get; set; } 
        public DbSet<Brand> Brands { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChargeManagementDbContext).Assembly);
          base.OnModelCreating(modelBuilder);
        }
    }
}