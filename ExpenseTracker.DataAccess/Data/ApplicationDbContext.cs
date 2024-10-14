using ExpenseTrackerWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Utilities" },
                new Category { Id = 2, Name = "Transport" },
                new Category { Id = 3, Name = "Foods" }
                );
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();
        }
    }
}
