using TDNI.Core.Models;
using TDNI.Core.Queries;

namespace TDNI.External.LocalStorage.Queries.GetPostsFromStorage
{
    public record GetPostsFromStorageQuery : IQuery<(IList<Post>, DateTime)> { }
}
