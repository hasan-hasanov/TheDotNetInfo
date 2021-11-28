using TDN.Core;
using TDN.Core.Models;
using TDN.Core.Queries;

namespace TDN.External.Blogs.Queries.GetBlogs
{
    public class GetBlogsQueryHandler : IQueryHandler<GetBlogsQuery, IList<BlogInfo>>
    {
        private readonly IAppSettings _appSettings;

        public GetBlogsQueryHandler(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public Task<IList<BlogInfo>> HandleAsync(GetBlogsQuery query, CancellationToken cancellationToken = default)
        {
            return Task.FromResult((IList<BlogInfo>)_appSettings.Blogs.ToList());
        }
    }
}
