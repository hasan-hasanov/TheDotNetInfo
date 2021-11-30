namespace TDNI.Core.Models
{
    public class Post
    {
        public Post()
        {
            Title = string.Empty;
            Link = string.Empty;
            Published = new DateTimeOffset();
            Author = string.Empty;
        }

        public string Title { get; set; }

        public string Link { get; set; }

        public DateTimeOffset Published { get; set; }

        public string Author { get; set; }
    }
}
