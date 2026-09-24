using HouseholdTasks.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseholdTasks.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options) { }

    public class HouseholdTasksDbContext : DbContext
    {
        public HouseholdTasksDbContext(DbContextOptions<HouseholdTasksDbContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HouseholdTasksDbContext).Assembly);
        }
    }
}
