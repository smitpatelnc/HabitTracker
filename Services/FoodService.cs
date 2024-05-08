// FoodService.cs
using HabitTracker.Data;
using HabitTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HabitTracker.Services
{
    public class FoodService
    {
        private readonly AppDbContext _context;

        public FoodService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Food>> GetFoodsAsync()
        {
            return await _context.Foods.ToListAsync();
        }

        public async Task AddFoodAsync(Food food)
        {
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFoodAsync(Food food)
        {
            _context.Entry(food).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFoodAsync(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food != null)
            {
                _context.Foods.Remove(food);
                await _context.SaveChangesAsync();
            }
        }
    }
}
