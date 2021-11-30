using TDNI.Core.Models;

namespace TheDotNetInfo.Store.Blogs.Actions
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
