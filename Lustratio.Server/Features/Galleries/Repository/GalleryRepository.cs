using Lustratio.Server.Data;
using Lustratio.Server.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lustratio.Server.Features.Galleries.Repository;

public class GalleryRepository : IGalleryRepository
{
    private readonly DataContext _context;
    
    public GalleryRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Gallery>> GetAllGalleriesAsync()
    {
        return await _context.Galleries
            .OrderBy(x => x.Id)
            .ToListAsync();
    }
    
    public async Task<Gallery> GetGalleryByIdAsync(int galleryId)
    {
        return await _context.Galleries
            .FirstOrDefaultAsync(x => x.Id == galleryId);
    }
}