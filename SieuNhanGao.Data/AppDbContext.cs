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
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(sc => new { sc.UserId, sc.RoleId });
            modelBuilder.Entity<BusinessRole>().HasMany(b => b.Roles).WithOne(p => p.BusinessRole)
                        .HasForeignKey(p => p.BusinessRoleId)
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PostCategory>().HasKey(sc => new { sc.PostId, sc.CategoryId });
            modelBuilder.Entity<PostTag>().HasKey(sc => new { sc.PostId, sc.TagId });
        }
    }
}