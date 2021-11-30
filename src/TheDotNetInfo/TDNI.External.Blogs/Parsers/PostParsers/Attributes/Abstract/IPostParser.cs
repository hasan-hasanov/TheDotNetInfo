using System.Xml;
using TDNI.Core.Models;

namespace TDNI.External.Blogs.Parsers.PostParsers.Attributes.Abstract
{
    public interface IPostParser
    {
        Task<IList<Post>> ParseAsync(XmlReader xmlReader, BlogInfo blog);
    }
}
