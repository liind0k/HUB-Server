using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Model.Model
{
    public class AdminDbContext: DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options) { }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Steps> Steps { get; set; }


        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Service>()
             .HasMany(sm => sm.Steps)
             .WithOne(s => s.service)
             .HasForeignKey(sm => sm.StepId);
        }
    }
}
