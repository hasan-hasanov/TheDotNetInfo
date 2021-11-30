using TDNI.Core.Commands;
using TDNI.Core.Models;

namespace TDNI.External.LocalStorage.Commands.SavePostsToStorage
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
