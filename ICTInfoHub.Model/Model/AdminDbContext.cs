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
        public DbSet<Admin> Admins { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Service> Services { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>().HasOne(a => a.Email);
        }
    }
}
