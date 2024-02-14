using Microsoft.EntityFrameworkCore;
using ToDoWeb.Models;

namespace ToDoWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ToDoItem> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDoItem>().HasData
                (
                new ToDoItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Сделать Дз",
                    Description = "Сделать русский и математику",
                    Created = DateTime.UtcNow.AddDays(2)
                },
                new ToDoItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Пойти на пробежку",
                    Created = DateTime.UtcNow.AddDays(2)
                }
                );
        }
    }
}
