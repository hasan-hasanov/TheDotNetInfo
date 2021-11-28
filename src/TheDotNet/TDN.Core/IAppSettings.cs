using TDN.Core.Models;

namespace TDN.Core
{
    public interface IAppSettings
    {
        public BlogInfo[] Blogs { get; }

        public int PostCount { get; }

        public int CacheDurationInHours { get; }
    }
}
