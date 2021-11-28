using Microsoft.SyndicationFeed;
using TDN.External.Blogs.Parsers.PostParsers.Attributes.Abstract;

namespace TDN.External.Blogs.Parsers.PostParsers.Attributes
{
    public class DescriptionParser : IAttributeParser<DescriptionParser>
    {
        public string Parse(ISyndicationItem item, params string[] args)
        {
            return item.Description;
        }
    }
}
