using AutoMapper;
using Lustratio.Server.Domain;
using Lustratio.Server.RepositoryManager;
using MediatR;

namespace Lustratio.Server.Features.Photos.Requests;

public class AddPhotoToGallery
{
    //Input
    public class AddPhotoToGalleryCommand : IRequest<PhotoResult>
    {
        public string PhotoUri { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime? PhotoDate { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int GalleryId { get; set; }
    }

    // Output
    public class PhotoResult
    {
        public int Id { get; set; }
        public string PhotoUri { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime? PhotoDate { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int GalleryId { get; set; }
    }

    // Handler
    public class Handler : IRequestHandler<AddPhotoToGalleryCommand, PhotoResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public Handler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<PhotoResult> Handle(AddPhotoToGalleryCommand request, CancellationToken cancellationToken)
        {
            var gallery = await _repositoryManager.Gallery.GetGalleryByIdAsync(request.GalleryId);

            // TODO: Custom exception
            if (gallery == null)
                throw new Exception($"Gallery with id {request.GalleryId} not found");

            var photo = new Photo()
            {
                PhotoUri = request.PhotoUri,
                UploadDate = request.UploadDate,
                PhotoDate = request.PhotoDate,
                Description = request.Description,
                Location = request.Location,
                Gallery = gallery,
                User = gallery.User
            };

            await _repositoryManager.Photo.AddPhotoToGalleryAsync(request.GalleryId, photo);
            await _repositoryManager.SaveAsync();

            var result = _mapper.Map<PhotoResult>(photo);

            return result;
        }
    }
}