namespace HabitTracker.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public string AbbreviatedContent { get; set; } 
        public DateTime PublishedDate { get; set; }
    }
}
