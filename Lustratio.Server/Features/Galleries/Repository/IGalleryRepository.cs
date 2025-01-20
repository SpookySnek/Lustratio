using Lustratio.Server.Domain;

namespace Lustratio.Server.Features.Galleries.Repository;

public interface IGalleryRepository
{
    Task<IEnumerable<Gallery>> GetAllGalleriesAsync();
    Task<Gallery> GetGalleryByIdAsync(int galleryId);
}