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

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Campus)
                .WithMany(c => c.Services)
                .HasForeignKey(s => s.CampusId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Campus)
                .WithMany(c => c.Departments)
                .UsingEntity<Dictionary<string, object>>(
            "CampusDepartment",
            j => j.HasOne<Campus>()
                  .WithMany()
                  .HasForeignKey("CampusId")
                  .OnDelete(DeleteBehavior.Cascade),
            j => j.HasOne<Department>()
                  .WithMany()
                  .HasForeignKey("DepartmentId")
                  .OnDelete(DeleteBehavior.Cascade),
            j =>
            {
                j.HasKey("CampusId", "DepartmentId");
                j.ToTable("CampusDepartment");
            });

            modelBuilder.Entity<News>()
                .HasMany(d => d.Campuses)
                .WithMany(c => c.News)
                .UsingEntity<Dictionary<string, object>>(
            "CampusNews",
            j => j.HasOne<Campus>()
                  .WithMany()
                  .HasForeignKey("CampusId")  
                  .OnDelete(DeleteBehavior.Cascade),
            j => j.HasOne<News>()
                  .WithMany()
                  .HasForeignKey("NewsId")   
                  .OnDelete(DeleteBehavior.Cascade),
            j =>
            {
                j.HasKey("CampusId", "NewsId");   
                j.ToTable("CampusNews");          
            });
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
