using Lustratio.Server.Features.Photos.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Lustratio.Server.Features.Photos.Requests.GetAllPhotosForGallery;
using static Lustratio.Server.Features.Photos.Requests.AddPhotoToGallery;

namespace Lustratio.Server.Features.Photos;

[Route("api/[controller]")]
[ApiController]
public class PhotosController : ControllerBase
{
    private readonly IMediator _mediator;

    public PhotosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllPhotosForGallery")]
    public async Task<ActionResult<IEnumerable<GetAllPhotosForGallery.PhotoResult>>> GetAllPhotosForGallery(int galleryId)
    {
        var query = new GetAllPhotosForGalleryQuery { GalleryId = galleryId };
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> AddPhotoToGallery(AddPhotoToGalleryCommand command)
    {
        var result = await _mediator.Send(command);

        return CreatedAtRoute("GetAllPhotosForGallery", new { galleryId = command.GalleryId }, result);
    }
    
    [HttpPut]
    public async Task<ActionResult> UpdatePhoto(int photoId, UpdatePhotoCommand command)
    {
        command.PhotoId = photoId;
        await _mediator.Send(command);
        
        return NoContent();
    }
    
    [HttpDelete]
    public async Task<ActionResult> RemovePhoto(int photoId, RemovePhotoCommand command)
    {
        command.PhotoId = photoId;
        await _mediator.Send(command);
        
        return NoContent();
    }
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Photo>>> GetAllPhotos()
    // {
    //     var photos = await _mediator.Send(new GetAllPhotosRequest());
    //     return Ok(photos);
    // }
    //
    // [HttpGet("{photoId}")]
    // public async Task<ActionResult<Photo>> GetPhotoById(int photoId)
    // {
    //     var photo = await _mediator.Send(new GetPhotoByIdRequest(photoId));
    //     return Ok(photo);
    // }

}