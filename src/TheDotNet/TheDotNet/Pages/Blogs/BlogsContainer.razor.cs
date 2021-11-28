using Fluxor;
using Microsoft.AspNetCore.Components;
using TheDotNet.Store.Blogs;
using TheDotNet.Store.Blogs.Actions;

namespace TheDotNet.Pages.Blogs
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
