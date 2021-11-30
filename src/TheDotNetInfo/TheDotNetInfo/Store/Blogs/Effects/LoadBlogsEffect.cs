using Fluxor;
using TDNI.Core.Models;
using TDNI.Core.Queries;
using TDNI.External.Blogs.Queries.GetBlogs;
using TheDotNetInfo.Store.Blogs.Actions;
using TheDotNetInfo.Store.Dom.Actions;

namespace TheDotNetInfo.Store.Blogs.Effects
{
    public class LoadBlogsEffect : Effect<LoadAllBlogsAction>
    {
        private readonly IQueryHandler<GetBlogsQuery, IList<BlogInfo>> _getBlogsQuery;

        public LoadBlogsEffect(IQueryHandler<GetBlogsQuery, IList<BlogInfo>> getBlogsQuery)
        {
            _getBlogsQuery = getBlogsQuery;
        }

        public override async Task HandleAsync(LoadAllBlogsAction action, IDispatcher dispatcher)
        {

            dispatcher.Dispatch(new SetLoadingAction(true));
            var blogs = await _getBlogsQuery.HandleAsync(new GetBlogsQuery());
            dispatcher.Dispatch(new SetLoadingAction(false));

            dispatcher.Dispatch(new SetBlogsAction(blogs));
        }
    }
}
