using TDN.Core.Models;

namespace TheDotNet.Store.Blogs
{
    public record BlogsState
    {
        public BlogsState()
        {
            Posts = new List<Post>();
            Blogs = new List<BlogInfo>();
        }

        public IList<Post> Posts { get; init; }

        public IList<BlogInfo> Blogs { get; init; }
    }
}
