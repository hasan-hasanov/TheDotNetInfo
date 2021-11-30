using Fluxor;
using TheDotNetInfo.Store.Blogs.Actions;

namespace TheDotNetInfo.Store.Blogs.Reducers
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
