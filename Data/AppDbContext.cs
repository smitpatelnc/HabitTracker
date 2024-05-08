using HabitTracker.Models;
using HabitTracker.Pages;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Routine> Routines { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<ExerciseTimer> ExerciseTimerData { get; set; } 
        public DbSet<Article> Articles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Routine>().HasKey(r => r.ID);
            modelBuilder.Entity<Habit>().HasKey(h => h.Id);
            modelBuilder.Entity<Food>().Ignore(f => f.ProteinPercentage);
            modelBuilder.Entity<Food>().Ignore(f => f.CarbohydratePercentage);
            modelBuilder.Entity<Food>().Ignore(f => f.FatPercentage);
        }
    }
}
