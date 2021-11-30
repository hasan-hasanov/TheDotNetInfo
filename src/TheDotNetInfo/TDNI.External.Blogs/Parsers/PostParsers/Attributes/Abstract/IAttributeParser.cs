using Microsoft.SyndicationFeed;

namespace TDNI.External.Blogs.Parsers.PostParsers.Attributes.Abstract
{
    public interface IAttributeParser<T>
    {
        string Parse(ISyndicationItem item, params string[] args);
    }
}
