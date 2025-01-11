using Lustratio.Server.Features.Users;

namespace Lustratio.Server.RepositoryManager;

public interface IRepositoryManager
{
    IUserRepository User { get; }
    // IGalleryRepository Gallery { get; }
    // IPhotoRepository Photo { get; }
    Task SaveAsync();
}