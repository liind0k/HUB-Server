using Microsoft.EntityFrameworkCore;

namespace ICTInfoHub.Model.Model
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options) { }

        // DbSets
        public DbSet<Admin> Admins { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Steps> Steps { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<News>()
                .Property(n => n.Priority)
                .HasConversion<string>(); 

            modelBuilder.Entity<News>()
                .Property(n => n.Category)
                .HasConversion<string>(); 

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

            modelBuilder.Entity<Department>()
                .HasOne(d => d.Campus)
                .WithMany(c => c.Departments)
                .HasForeignKey(d => d.CampusId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Campus>()
                .HasIndex(c => c.CampusName)
                .IsUnique();

            modelBuilder.Entity<Service>()
                .Property(s => s.Category)
                .HasConversion<string>();

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Campus)
                .WithMany(c => c.Services)
                .HasForeignKey(s => s.CampusId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Service>()
                .HasMany(s => s.Steps)
                .WithOne(st => st.service)
                .HasForeignKey(st => st.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
