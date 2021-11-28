using TDN.Core.Commands;

namespace TDN.External.LocalStorage.Commands.SavePostsToStorage
{
    public class SavePostsToStorageCommandHandler : ICommandHandler<SavePostsToStorageCommand>
    {
        private readonly LocalStorageContext _context;

        public SavePostsToStorageCommandHandler(LocalStorageContext context)
        {
            _context = context;
        }

        public async Task HandleAsync(SavePostsToStorageCommand command, CancellationToken cancellationToken = default)
        {
            await _context.SetItemAsync("posts", command.Posts, cancellationToken);
        }
    }
}
