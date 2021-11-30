using Fluxor;
using TheDotNetInfo.Store.Blogs.Actions;

namespace TheDotNetInfo.Store.Blogs.Reducers
{
    public class OnSetBlogsReducer : Reducer<BlogsState, SetBlogsAction>
    {
        public override BlogsState Reduce(BlogsState state, SetBlogsAction action)
        {
            return state with
            {
                Blogs = action.Blogs
            };
        }
    }
}
