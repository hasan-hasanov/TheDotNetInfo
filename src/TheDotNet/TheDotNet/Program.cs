using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TDN.Core;
using TDN.Core.Models;
using TDN.Core.Queries;
using TDN.External.Blogs;
using TDN.External.Blogs.Queries.GetRecentPosts;
using TheDotNet;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var http = new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
builder.Services.AddScoped(sp => http);
builder.Services.AddScoped<BlogsContext>();

using var response = await http.GetAsync("appSettings.json");
using var stream = await response.Content.ReadAsStreamAsync();

builder.Configuration.AddJsonStream(stream);
builder.Services.AddSingleton<IAppSettings>(provider => new AppSettings(builder.Configuration));
builder.Services.AddScoped<IQueryHandler<GetRecentPostsQuery, IList<Post>>, GetRecentPostsQueryHandler>();

var blogs = builder.Configuration.GetSection("blogs").Get<BlogInfo[]>();
foreach (var blog in blogs)
{
    var url = new Uri(blog.Url);
    builder.Services.AddHttpClient(url.Host, httpClient =>
    {
        httpClient.BaseAddress = url;
    });
}

builder.Services.AddFluxor(o => o
    .ScanAssemblies(typeof(Program).Assembly)
    .UseReduxDevTools());

await builder.Build().RunAsync();