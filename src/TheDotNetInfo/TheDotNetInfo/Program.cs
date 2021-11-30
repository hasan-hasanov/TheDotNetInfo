using Blazored.LocalStorage;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TDN.Core.Commands;
using TDNI.Core;
using TDNI.Core.Models;
using TDNI.Core.Queries;
using TDNI.External.Blogs;
using TDNI.External.Blogs.Parsers.PostParsers;
using TDNI.External.Blogs.Parsers.PostParsers.Attributes;
using TDNI.External.Blogs.Parsers.PostParsers.Attributes.Abstract;
using TDNI.External.Blogs.Queries.GetBlogs;
using TDNI.External.Blogs.Queries.GetRecentPosts;
using TDNI.External.LocalStorage;
using TDNI.External.LocalStorage.Commands.SavePostsToStorage;
using TDNI.External.LocalStorage.Queries.GetPostsFromStorage;
using TheDotNetInfo;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var http = new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
builder.Services.AddScoped(sp => http);

using var response = await http.GetAsync("appSettings.json");
using var stream = await response.Content.ReadAsStreamAsync();

builder.Configuration.AddJsonStream(stream);

builder.Services.AddSingleton<IAppSettings>(provider => new AppSettings(builder.Configuration));
builder.Services.AddScoped<IQueryHandler<GetRecentPostsQuery, IList<Post>>, GetRecentPostsQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetBlogsQuery, IList<BlogInfo>>, GetBlogsQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetPostsFromStorageQuery, (IList<Post>, DateTime)>, GetPostsFromStorageQueryHandler>();

builder.Services.AddScoped<ICommandHandler<SavePostsToStorageCommand>, SavePostsToStorageCommandHandler>();

builder.Services.AddScoped<IAttributeParser<AuthorParser>, AuthorParser>();
builder.Services.AddScoped<IAttributeParser<LinkParser>, LinkParser>();
builder.Services.AddScoped<IAttributeParser<PublishedParser>, PublishedParser>();
builder.Services.AddScoped<IAttributeParser<TitleParser>, TitleParser>();

builder.Services.AddScoped<IPostParser, PostParser>();

builder.Services.AddScoped<HttpContext>();
builder.Services.AddScoped<LocalStorageContext>();

var blogs = builder.Configuration.GetSection("blogs").Get<BlogInfo[]>();
foreach (var blog in blogs)
{
    var url = new Uri(blog.Url);
    builder.Services.AddHttpClient(url.Host, httpClient =>
    {
        httpClient.BaseAddress = url;
        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("TheDotNetInfo");
    });
}

builder.Services.AddFluxor(o => o
    .ScanAssemblies(typeof(Program).Assembly)
    .UseReduxDevTools());

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();