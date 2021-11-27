using TDN.Core.Models;

namespace TDN.Core
{
    public interface IAppSettings
    {
        public BlogInfo[] Blogs { get; }
    }
}
