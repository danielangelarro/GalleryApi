using GalleryApi.Application.DTO.Gallery;
using GalleryApi.Application.Entities;
using Microsoft.AspNetCore.Mvc;
using GalleryApi.Infrastructure.Repositories;
using GalleryApi.Application.Common.Interfaces;

namespace GalleryPhoto.API.Controllers;

[Route("fotos")]
public class GalleryPhotoController : ControllerBase
{
    private readonly IPhotoRepository _photoRepository;

    public GalleryPhotoController(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository;
    }

    [HttpGet]
    public ActionResult<GalleryResultList> GetPhotos()
    {
        return Ok(new GalleryResultList(_photoRepository.GetPhotos()));
    }

    [HttpGet("{id}")]
    public ActionResult<GalleryResult> DownloadPhoto(Guid id)
    {
        var photo = _photoRepository.GetPhotoById(id);

        if (photo is not Photo p)
        {
            return Problem(
                statusCode: StatusCodes.Status404NotFound,
                title: "Photo not found"
            );
        }

        return Ok(new GalleryResult(p));
    }
    
    [HttpGet("{userId}")]
    public ActionResult<GalleryResultList> GetPhotosByUser(Guid userId)
    {
        return Ok(new GalleryResultList(_photoRepository.GetPhotosByUser(userId)));
    }
    
    [HttpPost]
    public ActionResult<GalleryResult> UploadPhoto(GalleryUploadRequest request)
    {
        Photo photo = new Photo
        {
            Id = Guid.NewGuid(),
            FileDescription = request.FileDescription,
            FileName = request.FileName,
            Auth = request.User
        };

        using (var ms = new MemoryStream())
        {
            request.File.CopyToAsync(ms);
            photo.Contenido = ms.ToArray();
        }

        _photoRepository.Add(photo);

        return Ok(new GalleryResult(photo));
    }
    
    [HttpPut]
    public ActionResult<GalleryResult> UpdatePhoto(GalleryUpdateRequest request)
    {
        var photo = _photoRepository.GetPhotoById(request.FileId);

        if (photo is not Photo p)
        {
            return Problem(
                statusCode: StatusCodes.Status404NotFound,
                title: "Photo not found",
                detail: $"The photo with id '{request.FileId}' was not found."
            );
        }

        Photo newPhoto = new Photo
        {
            Id = request.FileId,
            FileDescription = request.FileDescription,
            FileName = request.FileName
        };

        _photoRepository.Put(newPhoto);

        return Ok(newPhoto);
    }
    
    [HttpDelete("fileId")]
    public ActionResult<GalleryResult> DeletePhoto(Guid fileId)
    {
        var photo = _photoRepository.GetPhotoById(fileId);

        if (photo is not Photo p)
        {
            return Problem(
                statusCode: StatusCodes.Status404NotFound,
                title: "Photo not found",
                detail: $"The photo with id '{fileId}' was not found."
            );
        }

        _photoRepository.Delete(photo);

        return Ok(photo);
    }
}