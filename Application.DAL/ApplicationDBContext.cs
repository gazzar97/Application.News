using Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DAL
{
    public class ApplicationDBContext : DbContext 
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
        public DbSet<Page> Pages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Page>(entity =>
            {
                entity.HasKey(p => p.ID);
                entity.Property(p => p.ID).ValueGeneratedOnAdd();
                entity.Property(p => p.PageTitle).IsRequired();

                // Seed initial data
                entity.HasData(
                    new Page { ID = 1, PageTitle = "Technology"},
                    new Page { ID = 2, PageTitle = "Business" },
                    new Page { ID = 3, PageTitle = "Entertainment" },
                    new Page { ID = 4, PageTitle = "Miscellaneous" }

                );
            });
        }
    }
}
