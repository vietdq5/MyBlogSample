using Microsoft.EntityFrameworkCore;
using SieuNhanGao.Data.EF.Entities;

namespace SieuNhanGao.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<BusinessRole> BusinessRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(sc => new {sc.UserId, sc.RoleId });
        }
    }
}