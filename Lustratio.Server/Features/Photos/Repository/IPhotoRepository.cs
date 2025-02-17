using Lustratio.Server.Domain;

namespace Lustratio.Server.Features.Photos.Repository;

public interface IPhotoRepository
{
    Task<IEnumerable<Photo>> GetAllPhotosAsync();
    Task<Photo> GetPhotoByIdAsync(int photoId);
    Task<IEnumerable<Photo>> GetAllPhotosForGalleryAsync(int galleryId);
}