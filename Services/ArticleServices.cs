using System;
using System.Collections.Generic;
using System.Linq;
using HabitTracker.Data;
using HabitTracker.Models;

namespace HabitTracker.Services
{
    public class ArticleService
    {
        private readonly AppDbContext _dbContext;

        public ArticleService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Article> GetAllArticles()
        {
            return _dbContext.Articles.ToList();
        }

        public Article GetArticleById(int id)
        {
            return _dbContext.Articles.FirstOrDefault(article => article.ArticleId == id);
        }
    }
}
