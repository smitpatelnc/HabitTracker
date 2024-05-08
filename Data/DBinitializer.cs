using HabitTracker.Data;
using HabitTracker.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HabitTracker.Models
{
    public static class DBInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            SeedHabits(context);
            SeedRoutines(context);
            SeedFoods(context);
            SeedArticles(context);
        }

        private static void SeedHabits(AppDbContext context)
        {
            if (!context.Habits.Any())
            {
                var habits = new List<Habit>
        {
            new Habit { Name = "Meditation", IsCompleted = true, DateAdded = DateTime.Now.AddDays(-5), DateCompleted = DateTime.Now.AddDays(-3), Description = "10 minutes of mindfulness meditation", Priority = 1, Category = "Mindfulness" },
            new Habit { Name = "Running", IsCompleted = false, DateAdded = DateTime.Now.AddDays(-10), Description = "Morning jog in the park", Priority = 2, Category = "Fitness" },
            new Habit { Name = "Reading", IsCompleted = true, DateAdded = DateTime.Now.AddDays(-15), DateCompleted = DateTime.Now.AddDays(-12), Description = "Read a chapter of a book", Priority = 3, Category = "Personal Development" },
            new Habit { Name = "Journaling", IsCompleted = false, DateAdded = DateTime.Now.AddDays(-20), Description = "Reflect on the day's events", Priority = 4, Category = "Self-Care" },
            new Habit { Name = "Yoga", IsCompleted = true, DateAdded = DateTime.Now.AddDays(-25), DateCompleted = DateTime.Now.AddDays(-21), Description = "30-minute yoga session", Priority = 1, Category = "Fitness" },
            new Habit { Name = "Coding", IsCompleted = false, DateAdded = DateTime.Now.AddDays(-30), Description = "Work on a coding project", Priority = 2, Category = "Skill Development" },
            new Habit { Name = "Gardening", IsCompleted = true, DateAdded = DateTime.Now.AddDays(-35), DateCompleted = DateTime.Now.AddDays(-32), Description = "Plant new flowers in the garden", Priority = 3, Category = "Hobby" }
        };

                context.Habits.AddRange(habits);
                context.SaveChanges();
            }
        }

        private static void SeedRoutines(AppDbContext context)
        {
            if (!context.Routines.Any())
            {
                var routines = new List<Routine>
        {
            new Routine
            {
                Name = "Morning Exercise",
                IsCompleted = true,
                Date = DateTime.Now.AddDays(-5),
                Description = "30 minutes of jogging and stretching",
                Priority = 1,
                Category = "Exercise",
                IsFlexible = false,
                Duration = TimeSpan.FromMinutes(30) // Adding duration
            },
            new Routine
            {
                Name = "Healthy Breakfast",
                IsCompleted = true,
                Date = DateTime.Now.AddDays(-5),
                Description = "Start the day with a nutritious breakfast",
                Priority = 2,
                Category = "Diet",
                IsFlexible = false,
                Duration = TimeSpan.FromMinutes(15) // Adding duration
            },
            new Routine
            {
                Name = "Evening Walk",
                IsCompleted = false,
                Date = DateTime.Now.AddDays(-10),
                Description = "20 minutes of walking in the park",
                Priority = 3,
                Category = "Exercise",
                IsFlexible = false,
                Duration = TimeSpan.FromMinutes(20) // Adding duration
            },
            new Routine
            {
                Name = "Healthy Snack",
                IsCompleted = false,
                Date = DateTime.Now.AddDays(-10),
                Description = "Eat a piece of fruit or nuts as a snack",
                Priority = 4,
                Category = "Diet",
                IsFlexible = false,
                Duration = TimeSpan.FromMinutes(10) // Adding duration
            }
        };

                context.Routines.AddRange(routines);
                context.SaveChanges();
            }
        }

        private static void SeedFoods(AppDbContext context)
        {
            if (!context.Foods.Any())
            {
                var vegetarianFoods = new List<Food>
        {
            new Food { Name = "Apple", Calories = 52, IsVegetarian = true, Category = "Fruits" },
            new Food { Name = "Banana", Calories = 89, IsVegetarian = true, Category = "Fruits" },
            new Food { Name = "Spinach", Calories = 23, IsVegetarian = true, Category = "Vegetables" },
            // Add other vegetarian foods without protein, fat, and carbohydrate values
        };

                var nonVegetarianFoods = new List<Food>
        {
            new Food { Name = "Chicken Breast", Calories = 165, IsVegetarian = false, Category = "Meat" },
            new Food { Name = "Salmon", Calories = 208, IsVegetarian = false, Category = "Fish" },
            // Add other non-vegetarian foods without protein, fat, and carbohydrate values
        };

                // Add all foods to the context
                context.Foods.AddRange(vegetarianFoods);
                context.Foods.AddRange(nonVegetarianFoods);

                // Calculate and set protein, fat, and carbohydrate values based on calories
                CalculateNutritionValues(context.Foods);

                context.SaveChanges();
            }
        }

        public static void SeedArticles(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // Seed the database with articles if it's empty
            if (!context.Articles.Any())
            {
                var articles = new Article[]
                {
                    new Article
                    {
                        Title = "7 Tips for a Balanced Diet",
                        Author = "John Doe",
                        Category = "Health",
                        Content = "Maintaining a balanced diet is essential for good health. It provides the necessary nutrients to fuel your body and keep you energized throughout the day. A balanced diet includes a variety of foods from all food groups, such as fruits, vegetables, whole grains, lean proteins, and healthy fats. Here are seven tips to help you achieve and maintain a balanced diet:\n\n1. Eat plenty of fruits and vegetables: These foods are rich in vitamins, minerals, and fiber, which are essential for overall health.\n\n2. Choose whole grains: Whole grains like brown rice, quinoa, and whole wheat bread are high in fiber and nutrients.\n\n3. Include lean protein sources: Opt for lean meats, poultry, fish, beans, and legumes as excellent sources of protein.\n\n4. Limit processed foods: Processed foods often contain high amounts of added sugars, unhealthy fats, and sodium. Try to minimize your intake of processed snacks and convenience foods.\n\n5. Stay hydrated: Drink plenty of water throughout the day to stay hydrated and support your body's functions.\n\n6. Control portion sizes: Pay attention to portion sizes to prevent overeating and maintain a healthy weight.\n\n7. Practice mindful eating: Take your time to savor and enjoy your meals, and pay attention to hunger and fullness cues.\n\nBy following these tips, you can improve your overall health and well-being with a balanced diet.",
                        AbbreviatedContent = "Maintaining a balanced diet is essential for good health. It provides the necessary nutrients to fuel your body..."
                    },
                    new Article
                    {
                        Title = "10 Effective Stress Management Techniques",
                        Author = "Jane Smith",
                        Category = "Wellness",
                        Content = "Stress is a common part of life, but it's important to manage it effectively to maintain your well-being. Here are 10 proven techniques to help you reduce stress and improve your quality of life:\n\n1. Practice deep breathing: Deep breathing exercises can help calm your mind and body, reducing stress and promoting relaxation.\n\n2. Exercise regularly: Physical activity is a great way to relieve stress and improve your mood. Aim for at least 30 minutes of moderate exercise most days of the week.\n\n3. Get enough sleep: Lack of sleep can increase stress levels and affect your ability to cope with challenges. Aim for 7-9 hours of quality sleep each night.\n\n4. Maintain a healthy diet: Eating a balanced diet can help support your body's stress response and improve your overall well-being.\n\n5. Practice mindfulness: Mindfulness involves paying attention to the present moment without judgment. It can help reduce stress and increase feelings of calm and relaxation.\n\n6. Connect with others: Spending time with friends and loved ones can provide emotional support and help buffer the effects of stress.\n\n7. Set boundaries: Learn to say no to activities or commitments that cause you stress or overwhelm you.\n\n8. Take breaks: Make time for relaxation and leisure activities that you enjoy, such as reading, listening to music, or spending time outdoors.\n\n9. Prioritize tasks: Break large tasks into smaller, manageable steps, and tackle them one at a time.\n\n10. Seek support: Don't be afraid to reach out for help if you're struggling to cope with stress. Talk to a trusted friend, family member, or mental health professional for support and guidance.\n\nBy incorporating these stress management techniques into your daily routine, you can reduce stress and improve your overall quality of life.",
                        AbbreviatedContent = "Stress is a common part of life, but it's important to manage it effectively to maintain your well-being..."
                    },
                    new Article
                    {
                        Title = "The Importance of Regular Exercise",
                        Author = "Michael Johnson",
                        Category = "Fitness",
                        Content = "Regular exercise can have numerous benefits for both your physical and mental health. It helps strengthen your muscles, improve your cardiovascular health, and boost your mood. Additionally, exercise can help reduce your risk of chronic diseases, such as heart disease, diabetes, and certain types of cancer. Here are some key reasons why regular exercise is important:\n\n1. Improves cardiovascular health: Exercise strengthens the heart and improves circulation, reducing your risk of heart disease and stroke.\n\n2. Builds muscle strength: Strength training exercises help build and maintain muscle mass, which is important for overall health and functionality.\n\n3. Enhances mood: Exercise releases endorphins, chemicals in the brain that promote feelings of happiness and reduce stress and anxiety.\n\n4. Supports weight management: Regular physical activity can help you maintain a healthy weight or lose excess weight by burning calories and increasing metabolism.\n\n5. Boosts energy levels: Exercise improves circulation and delivers oxygen and nutrients to your tissues, helping you feel more energized and alert.\n\n6. Promotes better sleep: Regular exercise can help regulate your sleep-wake cycle, leading to improved sleep quality and duration.\n\n7. Reduces risk of chronic diseases: Engaging in regular physical activity can lower your risk of developing chronic conditions like type 2 diabetes, high blood pressure, and osteoporosis.\n\n8. Improves cognitive function: Exercise has been shown to enhance brain health and cognitive function, including memory, attention, and problem-solving skills.\n\nBy incorporating regular exercise into your routine, you can enjoy these benefits and improve your overall health and well-being.",
                        AbbreviatedContent = "Regular exercise can have numerous benefits for both your physical and mental health. It helps strengthen your muscles, improve your cardiovascular health..."
                    },
                    new Article
                    {
                        Title = "5 Easy Ways to Improve Your Mental Health",
                        Author = "Emily Brown",
                        Category = "Mental Health",
                        Content = "Taking care of your mental health is just as important as taking care of your physical health. Here are five simple yet effective ways to improve your mental well-being:\n\n1. Practice self-care: Make time for activities that you enjoy and that help you relax and recharge, such as reading, spending time outdoors, or practicing mindfulness.\n\n2. Stay connected: Maintain strong relationships with friends and family members who provide support and encouragement during difficult times.\n\n3. Get moving: Physical activity is not only good for your body but also for your mind. Engage in regular exercise to boost your mood and reduce feelings of stress and anxiety.\n\n4. Limit screen time: Spending too much time on electronic devices can negatively impact your mental health. Set boundaries around screen time and prioritize activities that promote relaxation and well-being.\n\n5. Seek professional help: If you're struggling with your mental health, don't hesitate to reach out to a mental health professional for support and guidance. Therapy, counseling, and medication can all be effective treatments for mental health conditions.\n\nBy incorporating these strategies into your daily routine, you can improve your mental well-being and lead a happier, healthier life.",
                        AbbreviatedContent = "Taking care of your mental health is just as important as taking care of your physical health. Here are five simple yet effective ways to improve your mental well-being..."
                    },
                    new Article
                    {
                        Title = "The Power of Positive Thinking",
                        Author = "Alex Williams",
                        Category = "Personal Development",
                        Content = "Positive thinking can have a profound impact on your life. It can help reduce stress, increase resilience, and improve overall happiness and well-being. Here are some ways that positive thinking can benefit you:\n\n1. Reduces stress: Positive thinking can help reduce the harmful effects of stress on your body and mind by promoting feelings of calm and relaxation.\n\n2. Enhances resilience: When faced with challenges or setbacks, positive thinking can help you bounce back more quickly and effectively, allowing you to overcome obstacles and move forward with confidence.\n\n3. Improves relationships: Positive thinking can improve your relationships with others by fostering empathy, understanding, and communication. It can also help you attract positive people into your life who share your optimistic outlook.\n\n4. Boosts self-esteem: Positive thinking can boost your self-esteem and confidence, helping you believe in your abilities and pursue your goals with determination and enthusiasm.\n\n5. Increases happiness: Positive thinking promotes feelings of happiness, joy, and contentment, leading to a more fulfilling and satisfying life.\n\n6. Improves health outcomes: Studies have shown that positive thinking can have a positive impact on physical health outcomes, such as reducing the risk of chronic diseases and improving immune function.\n\nBy cultivating a positive mindset and incorporating positive thinking practices into your daily life, you can experience these benefits and live a happier, healthier, and more fulfilling life.",
                        AbbreviatedContent = "Positive thinking can have a profound impact on your life. It can help reduce stress, increase resilience, and improve overall happiness and well-being..."
                    }
                };

                context.Articles.AddRange(articles);
                context.SaveChanges();
            }
        }



    private static void CalculateNutritionValues(DbSet<Food> foods)
        {
            foreach (var food in foods)
            {
               
                food.Protein = food.Calories * 0.2; 
                food.Fat = food.Calories * 0.3;     
                food.Carbohydrates = food.Calories * 0.5; 
            }
        }

    }
}
