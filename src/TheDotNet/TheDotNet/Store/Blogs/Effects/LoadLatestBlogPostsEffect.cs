using Fluxor;
using TDN.Core.Models;
using TDN.Core.Queries;
using TDN.External.Blogs.Queries.GetRecentPosts;
using TheDotNet.Store.Blogs.Actions;

namespace TheDotNet.Store.Blogs.Effects
{
    public class LoadLatestBlogPostsEffect : Effect<LoadLatestBlogPostsAction>
    {
        private readonly ILogger<LoadLatestBlogPostsEffect> _logger;
        private readonly IQueryHandler<GetRecentPostsQuery, IList<Post>> _getRecentPostsQuery;

        public LoadLatestBlogPostsEffect(
            ILogger<LoadLatestBlogPostsEffect> logger,
            IQueryHandler<GetRecentPostsQuery, IList<Post>> getRecentPostsQuery)
        {
            _logger = logger;
            _getRecentPostsQuery = getRecentPostsQuery;
        }

        public override async Task HandleAsync(LoadLatestBlogPostsAction action, IDispatcher dispatcher)
        {
            _logger.LogInformation("Preparing to make a request");
            var posts = await _getRecentPostsQuery.HandleAsync(new GetRecentPostsQuery());

            dispatcher.Dispatch(new SetBlogPostsAction(posts));
        }
    }
}
