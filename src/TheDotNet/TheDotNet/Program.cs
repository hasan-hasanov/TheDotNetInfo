using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TDN.Core.Models;
using TheDotNet;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var http = new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
builder.Services.AddScoped(sp => http);

using var response = await http.GetAsync("appSettings.json");
using var stream = await response.Content.ReadAsStreamAsync();

builder.Configuration.AddJsonStream(stream);

var blogs = builder.Configuration.GetSection("blogs").Get<BlogInfo[]>();
foreach (var blog in blogs)
{
    builder.Services.AddHttpClient(blog.Url, httpClient =>
    {
        httpClient.BaseAddress = new Uri(blog.Url);
    });
}

builder.Services.AddFluxor(o => o
    .ScanAssemblies(typeof(Program).Assembly)
    .UseReduxDevTools());

await builder.Build().RunAsync();