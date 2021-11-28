using TDN.Core.Models;
using TDN.Core.Queries;

namespace TDN.External.LocalStorage.Queries.GetPostsFromStorage
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
