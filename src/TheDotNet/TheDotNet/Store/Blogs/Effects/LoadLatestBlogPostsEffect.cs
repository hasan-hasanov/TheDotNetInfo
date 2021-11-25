using Fluxor;
using TheDotNet.Store.Blogs.Actions;

namespace TheDotNet.Store.Blogs.Effects
{
    public class LoadLatestBlogPostsEffect : Effect<LoadLatestBlogPostsAction>
    {
        private readonly ILogger<LoadLatestBlogPostsEffect> _logger;

        public LoadLatestBlogPostsEffect(ILogger<LoadLatestBlogPostsEffect> logger)
        {
            _logger = logger;
        }

        public override async Task HandleAsync(LoadLatestBlogPostsAction action, IDispatcher dispatcher)
        {
            _logger.LogInformation("Preparing to make a request");
            await Task.Delay(1);
        }
    }
}
