using TDN.Core.Models;

namespace TheDotNet.Store.Blogs
{
    public record BlogsState
    {
        public BlogsState()
        {
            Posts = new List<Post>();
        }

        public IList<Post> Posts { get; init; }
    }
}
