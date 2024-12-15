using Microsoft.EntityFrameworkCore;
using Auth.Src.Models;


namespace Auth.Src.Data {
    public class DataContext : DbContext {
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Role> Roles { get; set; } = null!;

        public DbSet<Career> Careers { get; set; } = null!;

        public DbSet<BlacklistedToken> BlackListToken { get; set; } = null!;

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Role>().HasKey(r => r.Id);
            modelBuilder.Entity<Career>().HasKey(c => c.Id);
            modelBuilder.Entity<BlacklistedToken>().HasKey(b => b.Id);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Career)
                .WithMany()
                .HasForeignKey(u => u.CareerId);
        }
    }
}