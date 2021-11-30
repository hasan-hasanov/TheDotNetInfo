using Microsoft.SyndicationFeed;
using TDNI.External.Blogs.Parsers.PostParsers.Attributes.Abstract;

namespace TDNI.External.Blogs.Parsers.PostParsers.Attributes
{
    public class PublishedParser : IAttributeParser<PublishedParser>
    {
        public string Parse(ISyndicationItem item, params string[] args)
        {
            return item.Published != default ? item.Published.ToString() : item.LastUpdated.ToString();
        }
    }
}
