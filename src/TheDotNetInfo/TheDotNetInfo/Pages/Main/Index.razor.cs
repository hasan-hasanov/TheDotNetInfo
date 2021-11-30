using Fluxor;
using Microsoft.AspNetCore.Components;
using TheDotNetInfo.Store.Blogs;
using TheDotNetInfo.Store.Blogs.Actions;

namespace TheDotNetInfo.Pages.Main
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
