// IHabitService.cs

using HabitTracker.Models;


namespace HabitTracker.Services
{
    public interface IHabitService
    {
        Task<List<Habit>> GetHabitsAsync();
        Task AddHabitAsync(Habit habit);
        Task UpdateHabitAsync(int id, Habit habit);
        Task DeleteHabitAsync(int id);
    }
}
