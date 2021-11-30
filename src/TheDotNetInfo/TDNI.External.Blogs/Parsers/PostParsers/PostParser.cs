using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Atom;
using Microsoft.SyndicationFeed.Rss;
using System.Xml;
using TDNI.Core.Models;
using TDNI.External.Blogs.Parsers.PostParsers.Attributes;
using TDNI.External.Blogs.Parsers.PostParsers.Attributes.Abstract;
using TDNI.External.Blogs.Parsers.SyndicationParsers;

namespace TDNI.External.Blogs.Parsers.PostParsers
{
    public class PostParser : IPostParser
    {
        private readonly Func<XmlReader, XmlFeedReader> _feedFactory;

        private readonly IAttributeParser<TitleParser> _titleParser;
        private readonly IAttributeParser<LinkParser> _linkParser;
        private readonly IAttributeParser<PublishedParser> _publishedParser;
        private readonly IAttributeParser<AuthorParser> _authorParser;

        public PostParser(
            IAttributeParser<TitleParser> titleParser,
            IAttributeParser<LinkParser> linkParser,
            IAttributeParser<PublishedParser> publishedParser,
            IAttributeParser<AuthorParser> authorParser)
            : this(
                  titleParser,
                  linkParser,
                  publishedParser,
                  authorParser,
                  xml => xml.Name == "feed" ? new AtomFeedReader(xml, new DiscoverAtomParser()) : new RssFeedReader(xml))
        {
        }

        public PostParser(
            IAttributeParser<TitleParser> titleParser,
            IAttributeParser<LinkParser> linkParser,
            IAttributeParser<PublishedParser> publishedParser,
            IAttributeParser<AuthorParser> authorParser,
            Func<XmlReader, XmlFeedReader> factory)
        {
            _titleParser = titleParser;
            _linkParser = linkParser;
            _publishedParser = publishedParser;
            _authorParser = authorParser;

            _feedFactory = factory;
        }

        public async Task<IList<Post>> ParseAsync(XmlReader xmlReader, BlogInfo blog)
        {
            XmlFeedReader feedReader = _feedFactory.Invoke(xmlReader);
            IList<Post> posts = new List<Post>();

            while (await feedReader.Read())
            {
                if (feedReader.ElementType == SyndicationElementType.Item)
                {
                    var item = await feedReader.ReadItem();
                    string title = _titleParser.Parse(item);
                    string link = _linkParser.Parse(item);
                    string published = _publishedParser.Parse(item);
                    string author = _authorParser.Parse(item, blog.Author);

                    if (!string.IsNullOrEmpty(title) && published != default)
                    {
                        posts.Add(new Post()
                        {
                            Title = title,
                            Author = author,
                            Link = link,
                            Published = DateTimeOffset.Parse(published)
                        });
                    }
                }
            }

            return posts;
        }
    }
}
