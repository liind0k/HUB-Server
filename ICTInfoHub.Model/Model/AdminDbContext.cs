using Microsoft.EntityFrameworkCore;

namespace ICTInfoHub.Model.Model
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Steps> Steps { get; set; }
        public DbSet<Campus> Campuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<News>()
                .HasOne(n => n.Admin)
                .WithMany(a => a.News)
                .HasForeignKey(n => n.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<News>()
                .HasOne(n => n.Campus)
                .WithMany(c => c.News)
                .HasForeignKey(n => n.CampusId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Campus)
                .WithMany(c => c.Services)
                .HasForeignKey(s => s.CampusId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
