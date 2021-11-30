using TDNI.Core;
using TDNI.Core.Models;

namespace TheDotNetInfo
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfigurationSection _blogsSection;
        private readonly IConfigurationSection _postsSection;

        public AppSettings(IConfiguration configuration)
        {
            _blogsSection = configuration.GetSection("blogs");
            _postsSection = configuration.GetSection("posts");
        }

        public BlogInfo[] Blogs => _blogsSection.Get<BlogInfo[]>();

        public int PostCount => int.Parse(_postsSection["count"]);

        public int CacheDurationInHours => int.Parse(_postsSection["cacheDurationInHours"]);
    }
}
