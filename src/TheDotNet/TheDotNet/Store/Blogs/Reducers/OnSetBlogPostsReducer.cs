using Fluxor;
using TheDotNet.Store.Blogs.Actions;

namespace TheDotNet.Store.Blogs.Reducers
{
    public class OnSetBlogPostsReducer : Reducer<BlogsState, SetBlogPostsAction>
    {
        public override BlogsState Reduce(BlogsState state, SetBlogPostsAction action)
        {
            return state with
            {
                Posts = action.Posts
            };
        }
    }
}
