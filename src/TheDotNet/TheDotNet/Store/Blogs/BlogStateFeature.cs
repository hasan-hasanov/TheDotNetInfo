using Fluxor;
using TDN.Core.Models;

namespace TheDotNet.Store.Blogs
{
    public class BlogsStateFeature : Feature<BlogsState>
    {
        public override string GetName() => nameof(BlogsState);

        protected override BlogsState GetInitialState()
        {
            return new BlogsState
            {
                Blogs = new List<BlogInfo>(),
                Posts = new List<Post>()
            };
        }
    }
}
