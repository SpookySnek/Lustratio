using AutoMapper;
using Lustratio.Server.Domain;
using Lustratio.Server.RepositoryManager;
using MediatR;

namespace Lustratio.Server.Features.Photos.Requests;

public class GetAllPhotosForGallery
{
    // Request
    public class GetAllPhotosForGalleryQuery : IRequest<IEnumerable<PhotoResult>>
    {
        public int GalleryId { get; set; }
    }
    
    // Result
    public class PhotoResult
    {
        public int Id { get; set; }
        public required string PhotoUri { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime? PhotoDate { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int GalleryId { get; set; }
    }
    
    // Handler
    public class Handler : IRequestHandler<GetAllPhotosForGalleryQuery, IEnumerable<PhotoResult>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        
        public Handler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<PhotoResult>> Handle(GetAllPhotosForGalleryQuery request, CancellationToken cancellationToken)
        {
            var gallery = await _repositoryManager.Gallery.GetGalleryByIdAsync(request.GalleryId);
            
            if (gallery == null)
            {   // TODO: Custom exception
                throw new Exception($"Gallery with id {request.GalleryId} not found");
            }
            
            var photos = await _repositoryManager.Photo.GetAllPhotosForGalleryAsync(request.GalleryId);
            
            var result = _mapper.Map<IEnumerable<PhotoResult>>(photos);

            return result;
        }
    }
}