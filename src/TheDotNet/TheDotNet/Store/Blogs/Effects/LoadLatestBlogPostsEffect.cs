using Fluxor;
using TDN.Core;
using TDN.Core.Commands;
using TDN.Core.Models;
using TDN.Core.Queries;
using TDN.External.Blogs.Queries.GetRecentPosts;
using TDN.External.LocalStorage.Commands.SavePostsToStorage;
using TDN.External.LocalStorage.Queries.GetPostsFromStorage;
using TheDotNet.Store.Blogs.Actions;
using TheDotNet.Store.Dom.Actions;

namespace TheDotNet.Store.Blogs.Effects
{
    public class LoadLatestBlogPostsEffect : Effect<LoadLatestBlogPostsAction>
    {
        private readonly IAppSettings _appSettings;
        private readonly IQueryHandler<GetRecentPostsQuery, IList<Post>> _getRecentPostsQuery;
        private readonly IQueryHandler<GetPostsFromStorageQuery, (IList<Post>, DateTime)> _getPostsFromStorageQuery;
        private readonly ICommandHandler<SavePostsToStorageCommand> _savePostsToStorageCommand;

        public LoadLatestBlogPostsEffect(
            IAppSettings appSettings,
            IQueryHandler<GetRecentPostsQuery, IList<Post>> getRecentPostsQuery,
            IQueryHandler<GetPostsFromStorageQuery, (IList<Post>, DateTime)> getPostsFromStorageQuery,
            ICommandHandler<SavePostsToStorageCommand> savePostsToStorageCommand)
        {
            _appSettings = appSettings;
            _getRecentPostsQuery = getRecentPostsQuery;
            _getPostsFromStorageQuery = getPostsFromStorageQuery;
            _savePostsToStorageCommand = savePostsToStorageCommand;
        }

        public override async Task HandleAsync(LoadLatestBlogPostsAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetLoadingAction(true));
            (IList<Post> posts, DateTime lastUpdate) = await _getPostsFromStorageQuery.HandleAsync(new GetPostsFromStorageQuery());

            if (posts == null || DateTime.Now.AddHours(-_appSettings.CacheDurationInHours) > lastUpdate)
            {
                posts = await _getRecentPostsQuery.HandleAsync(new GetRecentPostsQuery());
                await _savePostsToStorageCommand.HandleAsync(new SavePostsToStorageCommand(posts));
            }

            dispatcher.Dispatch(new SetLoadingAction(false));
            dispatcher.Dispatch(new SetBlogPostsAction(posts));
        }
    }
}
