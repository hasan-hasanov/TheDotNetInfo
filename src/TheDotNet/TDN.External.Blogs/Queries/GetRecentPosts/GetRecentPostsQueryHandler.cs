﻿using System.Xml;
using TDN.Core;
using TDN.Core.Models;
using TDN.Core.Queries;
using TDN.External.Blogs.Parsers.PostParsers.Attributes.Abstract;

namespace TDN.External.Blogs.Queries.GetRecentPosts
{
    public class GetRecentPostsQueryHandler : IQueryHandler<GetRecentPostsQuery, IList<Post>>
    {
        private readonly IAppSettings _appSettings;
        private readonly HttpContext _context;
        private readonly IPostParser _postParser;
        private readonly Func<DateTimeOffset> _tresholdDate;
        private readonly Func<Stream, XmlReader> _xmlReaderFactory;

        public GetRecentPostsQueryHandler(
            IAppSettings appSettings,
            HttpContext context,
            IPostParser postParser)
            : this(
                  appSettings,
                  context,
                  postParser,
                  () => new DateTimeOffset(DateTime.Now.AddDays(-2)),
                  rssStream => XmlReader.Create(rssStream, new XmlReaderSettings { Async = true }))
        {
        }

        public GetRecentPostsQueryHandler(
            IAppSettings appSettings,
            HttpContext context,
            IPostParser postParser,
            Func<DateTimeOffset> yesterday,
            Func<Stream, XmlReader> xmlReaderFactory)
        {
            _appSettings = appSettings;
            _context = context;
            _postParser = postParser;
            _tresholdDate = yesterday;
            _xmlReaderFactory = xmlReaderFactory;
        }

        public async Task<IList<Post>> HandleAsync(GetRecentPostsQuery query, CancellationToken cancellationToken = default)
        {
            IList<Post> posts = new List<Post>();
            DateTimeOffset yesterday = _tresholdDate.Invoke();

            await Parallel.ForEachAsync(_appSettings.Blogs, async (blog, cts) =>
            {
                var url = new Uri(blog.Url);
                var httpClient = _context.CreateClient(url.Host);

                using Stream stream = await httpClient.GetStreamAsync(string.Empty, cts);
                using XmlReader xmlReader = _xmlReaderFactory(stream);

                var blogPosts = await _postParser.ParseAsync(xmlReader, blog);
                foreach (var blogPost in blogPosts)
                {
                    posts.Add(blogPost);
                }
            });

            return posts.OrderByDescending(p => p.Published).Take(_appSettings.PostCount).ToList();
        }
    }
}
