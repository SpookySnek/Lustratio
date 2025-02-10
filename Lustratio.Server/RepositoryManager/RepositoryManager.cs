using Lustratio.Server.Features.Users;
using Lustratio.Server.Features.Galleries;
using Lustratio.Server.Features.Photos;
using Lustratio.Server.Data;
using Lustratio.Server.Features.Galleries.Repository;
using Lustratio.Server.Features.Photos.Repository;
using Lustratio.Server.Features.Users.Repository;

namespace Lustratio.Server.RepositoryManager;

public class RepositoryManager : IRepositoryManager
{
    private readonly DataContext _context;
    private IUserRepository _userRepository;
    private IGalleryRepository _galleryRepository;
    private IPhotoRepository _photoRepository;
    
    public RepositoryManager(DataContext context)
    {
        _context = context;
    }

    public IUserRepository User
    {
        get
        {
            if (_userRepository == null)
            {
                _userRepository = new UserRepository(_context);
            }
            
            return _userRepository;
        }
    }
    
    public IGalleryRepository Gallery
    {
        get
        {
            if (_galleryRepository == null)
            {
                _galleryRepository = new GalleryRepository(_context);
            }
            
            return _galleryRepository;
        }
    }
    
    public IPhotoRepository Photo
    {
        get
        {
            if (_photoRepository == null)
            {
                _photoRepository = new PhotoRepository(_context);
            }
            
            return _photoRepository;
        }
    }
    
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}

// Switch to implicit lazy loading?