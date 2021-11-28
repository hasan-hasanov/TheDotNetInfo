using Fluxor;
using TheDotNet.Store.Blogs.Actions;

namespace TheDotNet.Store.Blogs.Reducers
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
