using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;
using System.Xml;
using TDN.Core;
using TDN.Core.Models;
using TDN.Core.Queries;

namespace TDN.External.Blogs.Queries.GetRecentPosts
{
    public class GetRecentPostsQueryHandler : IQueryHandler<GetRecentPostsQuery, IList<Post>>
    {
        private readonly IAppSettings _appSettings;
        private readonly BlogsContext _context;

        public GetRecentPostsQueryHandler(
            IAppSettings appSettings,
            BlogsContext context)
        {
            _appSettings = appSettings;
            _context = context;
        }

        public async Task<IList<Post>> HandleAsync(GetRecentPostsQuery query, CancellationToken cancellationToken = default)
        {
            IList<Post> posts = new List<Post>();
            await Parallel.ForEachAsync(_appSettings.Blogs, async (blog, cts) =>
            {
                var url = new Uri(blog.Url);
                var httpClient = _context.CreateClient(url.Host);

                using Stream stream = await httpClient.GetStreamAsync(string.Empty, cts);
                using XmlReader xmlReader = XmlReader.Create(stream, new XmlReaderSettings
                {
                    Async = true
                });

                var feedReader = new RssFeedReader(xmlReader);
                while (await feedReader.Read())
                {
                    if (feedReader.ElementType == SyndicationElementType.Item)
                    {
                        var item = await feedReader.ReadItem();
                        posts.Add(new Post()
                        {
                            // TODO: Get the author from the feed
                            Author = blog.Author,
                            Description = item.Description,
                            Published = item.Published != default ? item.Published : item.LastUpdated,
                            Title = item.Title,

                            // TODO: Fix this url and make it dynamic
                            Url = string.Empty
                        });
                    }
                }
            });

            return posts;
        }
    }
}
