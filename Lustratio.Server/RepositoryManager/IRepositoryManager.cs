using Lustratio.Server.Features.Galleries;
using Lustratio.Server.Features.Galleries.Repository;
using Lustratio.Server.Features.Photos;
using Lustratio.Server.Features.Photos.Repository;
using Lustratio.Server.Features.Users;
using Lustratio.Server.Features.Users.Repository;

namespace Lustratio.Server.RepositoryManager;

public interface IRepositoryManager
{
    IUserRepository User { get; }
    IGalleryRepository Gallery { get; }
    IPhotoRepository Photo { get; }
    Task SaveAsync();
}