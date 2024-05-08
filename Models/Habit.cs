using System;
using System.ComponentModel.DataAnnotations;

namespace HabitTracker.Models
{
    public class Habit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 100 characters.")]
        public string? Name { get; set; }

        public bool IsCompleted { get; set; }

        [Required(ErrorMessage = "Date added is required.")]
        public DateTime DateAdded { get; set; }

        public DateTime? DateCompleted { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [Range(1, 10, ErrorMessage = "Priority must be between 1 and 10.")]
        public int Priority { get; set; }

        [StringLength(50, ErrorMessage = "Category cannot exceed 50 characters.")]
        public string? Category { get; set; }
    }
}
