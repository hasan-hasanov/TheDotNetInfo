using Fluxor;
using TDN.Core.Models;
using TDN.Core.Queries;
using TDN.External.Blogs.Queries.GetBlogs;
using TheDotNet.Store.Blogs.Actions;
using TheDotNet.Store.Dom.Actions;

namespace TheDotNet.Store.Blogs.Effects
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
