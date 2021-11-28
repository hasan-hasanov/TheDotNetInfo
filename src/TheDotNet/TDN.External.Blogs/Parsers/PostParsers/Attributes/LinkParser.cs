using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;
using TDN.External.Blogs.Parsers.PostParsers.Attributes.Abstract;

namespace TDN.External.Blogs.Parsers.PostParsers.Attributes
{
    public class LinkParser : IAttributeParser<LinkParser>
    {
        public string Parse(ISyndicationItem item, params string[] args)
        {
            string link = item.Id;
            ISyndicationLink? firstLink = item?.Links?.FirstOrDefault(x => x.RelationshipType == RssLinkTypes.Alternate);
            if (firstLink != null)
            {
                link = firstLink.Uri.IsAbsoluteUri ?
                    firstLink.Uri.AbsoluteUri :
                    new Uri(new Uri(args[0]), firstLink.Uri).AbsoluteUri;
            }

            return link;
        }
    }
}
