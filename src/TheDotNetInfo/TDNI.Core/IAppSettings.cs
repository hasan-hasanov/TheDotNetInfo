using TDNI.Core.Models;

namespace TDNI.Core
{
    public interface IAppSettings
    {
        public BlogInfo[] Blogs { get; }

        public int PostCount { get; }

        public int CacheDurationInHours { get; }
    }
}
