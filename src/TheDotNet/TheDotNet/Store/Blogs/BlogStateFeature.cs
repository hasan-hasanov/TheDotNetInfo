using Fluxor;

namespace TheDotNet.Store.Blogs
{
    public class BlogsStateFeature : Feature<BlogsState>
    {
        public override string GetName() => nameof(BlogsState);

        protected override BlogsState GetInitialState()
        {
            return new BlogsState
            {

            };
        }
    }
}
