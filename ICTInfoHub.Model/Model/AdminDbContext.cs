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
        public DbSet<Module> Modules { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<News>()
                .Property(n => n.Priority)
                .HasConversion<string>();

            modelBuilder.Entity<Campus>()
                .HasIndex(c => c.CampusName)
                .IsUnique();

            modelBuilder.Entity<Course>()
                .HasIndex(c => c.CourseCode)
                .IsUnique();

            modelBuilder.Entity<Service>()
                .Property(s => s.Category)
                .HasConversion<string>();

            modelBuilder.Entity<News>()
                .Property(n => n.Category)
                .HasConversion<string>();

            modelBuilder.Entity<CampusDepartment>()
                .HasOne(cd => cd.Campus)
                .WithMany(c => c.CampusDepartments)
                .HasForeignKey(cd => cd.CampusId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CampusDepartment>()
                .HasOne(cd => cd.Department)
                .WithMany(d => d.CampusDepartments)
                .HasForeignKey(cd => cd.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<Course>()
        .HasMany(c => c.Modules)
        .WithMany(m => m.Courses)
        .UsingEntity<Dictionary<string, object>>(
            "CourseModule",
            j => j.HasOne<Module>()
                  .WithMany()
                  .HasForeignKey("ModuleId")
                  .OnDelete(DeleteBehavior.Cascade),
            j => j.HasOne<Course>()
                  .WithMany()
                  .HasForeignKey("CourseId")
                  .OnDelete(DeleteBehavior.Cascade),
            j =>
            {
                j.HasKey("CourseId", "ModuleId");
                j.ToTable("CourseModule");
            });

            modelBuilder.Entity<Campus>()
                .HasMany(c => c.CampusServices)
                .WithOne(s => s.Campus)
                .HasForeignKey(s => s.CampusId);

            modelBuilder.Entity<Steps>()
                .HasOne(s => s.CampusService)
                .WithMany(cs => cs.Steps)
                .HasForeignKey(s => s.CampusServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Contact>()
                .HasMany(d => d.Modules)
                .WithMany(c => c.Contacts)
                .UsingEntity<Dictionary<string, object>>(
            "ModuleContact",
            j => j.HasOne<Module>()
                  .WithMany()
                  .HasForeignKey("ModuleCode")
                  .OnDelete(DeleteBehavior.Cascade),
            j => j.HasOne<Contact>()
                  .WithMany()
                  .HasForeignKey("ContactId")
                  .OnDelete(DeleteBehavior.Cascade),
            j =>
            {
                j.HasKey("ModuleCode", "ContactId");
                j.ToTable("ModuleContact");
            });


        }
    }
}
