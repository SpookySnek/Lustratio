using AutoMapper;
using Lustratio.Server.Domain;
using Lustratio.Server.RepositoryManager;
using MediatR;

namespace Lustratio.Server.Features.Photos.Requests;

public class GetAllPhotosForGallery
{
    public class GetAllPhotosForGalleryQuery : IRequest<IEnumerable<Photo>>
    {
        public int GalleryId { get; set; }
    }
    
    public class PhotoResult
    {
        public int Id { get; set; }
        public required string PhotoUri { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime? PhotoDate { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
    }

    public class Handler : IRequestHandler<GetAllPhotosForGalleryQuery, IEnumerable<PhotoResult>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        
        public Handler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
    }
}