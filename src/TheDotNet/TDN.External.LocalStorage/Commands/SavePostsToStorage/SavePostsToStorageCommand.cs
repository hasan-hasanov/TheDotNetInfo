using TDN.Core.Commands;
using TDN.Core.Models;

namespace TDN.External.LocalStorage.Commands.SavePostsToStorage
{
    public record SavePostsToStorageCommand : ICommand
    {
        public SavePostsToStorageCommand(IList<Post> posts)
        {
            Posts = posts;
        }

        public IList<Post> Posts { get; }
    }
}
