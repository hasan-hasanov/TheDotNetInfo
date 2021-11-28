using TDN.Core.Models;

namespace TheDotNet.Store.Blogs.Actions
{
    public record SetBlogsAction
    {
        public SetBlogsAction(IList<BlogInfo> blogs)
        {
            Blogs = blogs;
        }

        public IList<BlogInfo> Blogs { get; }
    }
}
