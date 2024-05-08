using System;

namespace HabitTracker.Models
{
    public class ExerciseTimer
    {       
            public int Id { get; set; }
            public string ExerciseName { get; set; }
            public TimeSpan ElapsedTime { get; set; }
            public double CaloriesBurned { get; set; }
            public DateTime Timestamp { get; set; }
        }
    }
