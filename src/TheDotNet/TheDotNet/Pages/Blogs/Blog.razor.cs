using Microsoft.AspNetCore.Components;

namespace TheDotNet.Pages.Blogs
{
    public partial class Blog
    {
        [Parameter] public string Url { get; set; }

        [Parameter] public string Author { get; set; }

        [Parameter] public string Title { get; set; }
    }
}
