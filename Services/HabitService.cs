// HabitService.cs

using HabitTracker.Models;

namespace HabitTracker.Services
{
    public class HabitService : IHabitService
    {
        private List<Habit> _habits = new List<Habit>();

        public async Task<List<Habit>> GetHabitsAsync()
        {
            await Task.Delay(100); // Simulate async operation
            return _habits;
        }

        public async Task AddHabitAsync(Habit habit)
        {
            await Task.Delay(100); // Simulate async operation
            habit.Id = _habits.Count + 1;
            _habits.Add(habit);
        }

        public async Task UpdateHabitAsync(int id, Habit habit)
        {
            await Task.Delay(100); // Simulate async operation
            var existingHabit = _habits.FirstOrDefault(h => h.Id == id);
            if (existingHabit != null)
            {
                existingHabit.Name = habit.Name;
                existingHabit.IsCompleted = habit.IsCompleted;
            }
        }

        public async Task DeleteHabitAsync(int id)
        {
            await Task.Delay(100); // Simulate async operation
            _habits.RemoveAll(h => h.Id == id);
        }
    }
}
