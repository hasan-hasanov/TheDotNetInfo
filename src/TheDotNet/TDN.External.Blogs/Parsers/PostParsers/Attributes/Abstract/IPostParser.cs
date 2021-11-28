using System.Xml;
using TDN.Core.Models;

namespace TDN.External.Blogs.Parsers.PostParsers.Attributes.Abstract
{
    public interface IPostParser
    {
        Task<IList<Post>> ParseAsync(XmlReader xmlReader, BlogInfo blog);
    }
}
