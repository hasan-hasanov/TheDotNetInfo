using TDNI.Core.Models;
using TDNI.Core.Queries;

namespace TDNI.External.LocalStorage.Queries.GetPostsFromStorage
{
    public class GetPostsFromStorageQueryHandler : IQueryHandler<GetPostsFromStorageQuery, (IList<Post>, DateTime)>
    {
        private readonly LocalStorageContext _context;

        public GetPostsFromStorageQueryHandler(LocalStorageContext context)
        {
            _context = context;
        }

        public async Task<(IList<Post>, DateTime)> HandleAsync(
            GetPostsFromStorageQuery query,
            CancellationToken cancellationToken = default)
        {
            var posts = await _context.GetItemAsync<List<Post>>("posts", cancellationToken);
            return posts;
        }
    }
}
