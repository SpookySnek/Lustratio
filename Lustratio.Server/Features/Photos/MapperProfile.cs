using AutoMapper;
using Lustratio.Server.Domain;
using Lustratio.Server.Features.Photos.Requests;

namespace Lustratio.Server.Features.Photos;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // TODO: DTO?
        // TODO: Switch to mapster
        CreateMap<Photo, GetAllPhotosForGallery.PhotoResult>();
        CreateMap<Photo, AddPhotoToGallery.PhotoResult>();
    }
}