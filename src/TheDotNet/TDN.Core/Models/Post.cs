namespace TDN.Core.Models
{
    public class Post
    {
        public Post()
        {
            Title = string.Empty;
            Url = string.Empty;
            Description = string.Empty;
            Published = new DateTime();
            Author = string.Empty;
        }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public DateTime Published { get; set; }

        public string Author { get; set; }
    }
}
