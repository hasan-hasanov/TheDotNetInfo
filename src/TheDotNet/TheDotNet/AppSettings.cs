using TDN.Core;
using TDN.Core.Models;

namespace TheDotNet
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfigurationSection _blogsSection;

        public AppSettings(IConfiguration configuration)
        {
            _blogsSection = configuration.GetSection("blogs");
        }

        public BlogInfo[] Blogs => _blogsSection.Get<BlogInfo[]>();
    }
}
