using TaskManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TaskManagement.Repositories
{
    public class MainDbContext : DbContext
    {
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<Tasks> Tasks => Set<Tasks>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=taskmanagement;Username=postgres;Password=123456");
    }
}
