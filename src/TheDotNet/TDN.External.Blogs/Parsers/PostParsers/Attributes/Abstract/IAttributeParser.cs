using Microsoft.SyndicationFeed;

namespace TDN.External.Blogs.Parsers.PostParsers.Attributes.Abstract
{
    public interface IAttributeParser<T>
    {
        string Parse(ISyndicationItem item, params string[] args);
    }
}
