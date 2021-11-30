using Fluxor;
using Microsoft.AspNetCore.Components;
using TheDotNetInfo.Store.Blogs;
using TheDotNetInfo.Store.Blogs.Actions;

namespace TheDotNetInfo.Pages.Blogs
{
    public partial class BlogsContainer
    {
        [Inject] public IDispatcher Dispatcher { get; set; }

        [Inject] public IState<BlogsState> BlogsState { get; set; }

        protected override Task OnInitializedAsync()
        {
            Dispatcher.Dispatch(new LoadAllBlogsAction());
            return base.OnInitializedAsync();
        }
    }
}
