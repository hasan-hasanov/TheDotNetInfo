using Fluxor;
using Microsoft.AspNetCore.Components;
using TheDotNet.Store.Blogs;
using TheDotNet.Store.Blogs.Actions;

namespace TheDotNet.Pages.Main
{
    public partial class Index
    {
        [Inject] public IDispatcher Dispatcher { get; set; }

        [Inject] public IState<BlogsState> BlogsState { get; set; }

        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new LoadLatestBlogPostsAction());
            return base.OnInitializedAsync();
        }
    }
}
