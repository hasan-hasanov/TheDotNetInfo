using TDN.Core.Models;

namespace TheDotNet.Store.Blogs.Actions
{
    public record SetBlogPostsAction
    {
        public SetBlogPostsAction(IList<Post> posts)
        {
            Posts = posts;
        }

        public IList<Post> Posts { get; }
    }
}
