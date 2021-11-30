namespace TDNI.Core.Models
{
    public class BlogInfo
    {
        public BlogInfo()
        {
            Url = string.Empty;
            Author = string.Empty;
            Title = string.Empty;
        }

        public string Url { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }
    }
}
