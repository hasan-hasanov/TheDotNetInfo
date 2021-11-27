using TDN.Core.Models;
using TDN.Core.Queries;

namespace TDN.External.Blogs.Queries.GetRecentPosts
{
    public class GetRecentPostsQueryHandler : IQueryHandler<GetRecentPostsQuery, IList<Post>>
    {
        public Task<IList<Post>> HandleAsync(GetRecentPostsQuery query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
