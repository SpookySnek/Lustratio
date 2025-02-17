using Lustratio.Server.Data;
using Lustratio.Server.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lustratio.Server.Features.Photos.Repository;

public class PhotoRepository : IPhotoRepository
{
    private readonly DataContext _context;
    
    public PhotoRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Photo>> GetAllPhotosAsync()
    {
        return await _context.Photos
            .OrderBy(x => x.Id)
            .ToListAsync();
    }
    
    public async Task<Photo> GetPhotoByIdAsync(int photoId)
    {
        return await _context.Photos
            .FirstOrDefaultAsync(x => x.Id == photoId);
    }
    
    public async Task<IEnumerable<Photo>> GetAllPhotosForGalleryAsync(int galleryId)
    {
        return await _context.Photos
            .Where(x => x.Gallery.Id == galleryId)
            .OrderBy(x => x.Id)
            .ToListAsync();
    }
}