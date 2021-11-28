﻿using Microsoft.AspNetCore.Components;

namespace TheDotNet.Pages.Main
{
    public partial class Post
    {
        [Parameter] public string Title { get; set; }

        [Parameter] public string Url { get; set; }

        [Parameter] public string Description { get; set; }

        [Parameter] public string Author { get; set; }
    }
}