using Microsoft.SyndicationFeed;
using TDN.External.Blogs.Parsers.PostParsers.Attributes.Abstract;

namespace TDN.External.Blogs.Parsers.PostParsers.Attributes
{
    public class AuthorParser : IAttributeParser<AuthorParser>
    {
        public string Parse(ISyndicationItem item, params string[] args)
        {
            string author = args[0];
            ISyndicationPerson? person = item.Contributors.FirstOrDefault(x => x.RelationshipType == "author");
            if (person != null)
            {
                author = person.Name ?? person.Email;
            }

            return author;
        }
    }
}
