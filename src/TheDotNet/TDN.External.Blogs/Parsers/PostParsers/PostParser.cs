using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Atom;
using Microsoft.SyndicationFeed.Rss;
using System.Xml;
using TDN.Core.Models;
using TDN.External.Blogs.Parsers.PostParsers.Attributes;
using TDN.External.Blogs.Parsers.PostParsers.Attributes.Abstract;

namespace TDN.External.Blogs.Parsers.PostParsers
{
    public class PostParser : IPostParser
    {
        private readonly Func<XmlReader, XmlFeedReader> _feedFactory;

        private readonly IAttributeParser<TitleParser> _titleParser;
        private readonly IAttributeParser<LinkParser> _linkParser;
        private readonly IAttributeParser<DescriptionParser> _descriptionParser;
        private readonly IAttributeParser<PublishedParser> _publishedParser;
        private readonly IAttributeParser<TitleParser> _authorParser;

        public PostParser(
            IAttributeParser<TitleParser> titleParser,
            IAttributeParser<LinkParser> linkParser,
            IAttributeParser<DescriptionParser> descriptionParser,
            IAttributeParser<PublishedParser> publishedParser,
            IAttributeParser<TitleParser> authorParser)
            : this(
                  titleParser,
                  linkParser,
                  descriptionParser,
                  publishedParser,
                  authorParser,
                  xml => xml.Name == "feed" ? new AtomFeedReader(xml) : new RssFeedReader(xml))
        {
        }

        public PostParser(
            IAttributeParser<TitleParser> titleParser,
            IAttributeParser<LinkParser> linkParser,
            IAttributeParser<DescriptionParser> descriptionParser,
            IAttributeParser<PublishedParser> publishedParser,
            IAttributeParser<TitleParser> authorParser,
            Func<XmlReader, XmlFeedReader> factory)
        {
            _titleParser = titleParser;
            _linkParser = linkParser;
            _descriptionParser = descriptionParser;
            _publishedParser = publishedParser;
            _authorParser = authorParser;

            _feedFactory = factory;
        }

        public async Task<IList<Post>> ParseAsync(XmlReader xmlReader)
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
                    string description = _descriptionParser.Parse(item);
                    string published = _publishedParser.Parse(item);
                    string author = _authorParser.Parse(item);

                    posts.Add(new Post()
                    {
                        Title = title,
                        Author = author,
                        Link = link,
                        Description = description,
                        Published = DateTimeOffset.Parse(published)
                    });
                }
            }

            return posts;
        }
    }
}
