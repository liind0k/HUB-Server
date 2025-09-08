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

            modelBuilder.Entity<CampusService>()
                .HasOne(cs => cs.Campus)
                .WithMany(s => s.CampusServices)
                .HasForeignKey(cs => cs.CampusId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CampusService>()
                .HasOne(cs => cs.service)
                .WithMany(s => s.CampusServices)
                .HasForeignKey(cs => cs.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<Course>()
                .HasKey(c => c.CourseCode);

            modelBuilder.Entity<Service>()
                .Property(s => s.Category)
                .HasConversion<string>();


            modelBuilder.Entity<Campus>()
                .HasMany(c => c.CampusServices)
                .WithOne(s => s.Campus)
                .HasForeignKey(s => s.CampusId);

            modelBuilder.Entity<Steps>()
                .HasOne(s => s.CampusService)
                .WithMany(cs => cs.Steps)
                .HasForeignKey(s => s.CampusServiceId)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
