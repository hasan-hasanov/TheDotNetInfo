using TDNI.Core.Models;

namespace TheDotNetInfo.Store.Blogs.Actions
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
