using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HabitTracker.Models
{
    public class Food
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Calories are required")]
        [Range(0, int.MaxValue, ErrorMessage = "Calories must be a non-negative number")]
        public int Calories { get; set; }

        public bool IsVegetarian { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        private double _protein;

        [Required(ErrorMessage = "Protein value is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Protein must be a non-negative number")]
        public double Protein
        {
            get => _protein;
            set
            {
                _protein = value;
                UpdateNutritionPercentages();
            }
        }


        private double _carbohydrates;

        [Required(ErrorMessage = "Carbohydrates value is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Carbohydrates must be a non-negative number")]
        public double Carbohydrates
        {
            get => _carbohydrates;
            set
            {
                _carbohydrates = value;
                UpdateNutritionPercentages();
            }
        }

        private double _fat;

        [Required(ErrorMessage = "Fat value is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Fat must be a non-negative number")]
        public double Fat
        {
            get => _fat;
            set
            {
                _fat = value;
                UpdateNutritionPercentages();
            }
        }

        // Nutrition percentages - these are not mapped to the database
        [NotMapped]
        public double ProteinPercentage { get; private set; }

        [NotMapped]
        public double CarbohydratePercentage { get; private set; }

        [NotMapped]
        public double FatPercentage { get; private set; }

        // Method to update nutritional percentages
        public void UpdateNutritionPercentages()
        {
            double totalCalories = Calories;

            if (totalCalories > 0)
            {
                if (IsVegetarian)
                {
                    ProteinPercentage = Math.Round((Protein / totalCalories) * 100, 2);
                    CarbohydratePercentage = Math.Round((Carbohydrates / totalCalories) * 100, 2);
                    FatPercentage = Math.Round((Fat / totalCalories) * 100, 2);
                }
                else
                {
                    ProteinPercentage = Math.Round((Protein / totalCalories) * 100, 2);
                    CarbohydratePercentage = Math.Round((Carbohydrates / totalCalories) * 100, 2);
                    FatPercentage = Math.Round((Fat / totalCalories) * 100, 2);
                }
            }
            else
            {
                // If total calories are zero, set percentages to zero
                ProteinPercentage = 0;
                CarbohydratePercentage = 0;
                FatPercentage = 0;
            }
        }

    }
}
