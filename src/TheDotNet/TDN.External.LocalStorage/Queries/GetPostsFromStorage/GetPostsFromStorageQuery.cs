using TDN.Core.Models;
using TDN.Core.Queries;

namespace TDN.External.LocalStorage.Queries.GetPostsFromStorage
{
    public record GetPostsFromStorageQuery : IQuery<(IList<Post>, DateTime)> { }
}
