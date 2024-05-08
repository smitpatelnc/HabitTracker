using System;
using System.ComponentModel.DataAnnotations;

namespace HabitTracker.Models
{
    public class Routine
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public bool IsCompleted { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Range(1, 10, ErrorMessage = "Priority must be between 1 and 10.")]
        public int Priority { get; set; }

        [StringLength(50, ErrorMessage = "Category cannot exceed 50 characters.")]
        public string Category { get; set; }

        public TimeSpan Duration { get; set; }

        public string Location { get; set; }

        public bool IsFlexible { get; set; }

        public DateTime NextOccurrence { get; set; }

        [StringLength(500, ErrorMessage = "Resources needed cannot exceed 500 characters.")]
        public string ResourcesNeeded { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string Notes { get; set; }
    }
}
