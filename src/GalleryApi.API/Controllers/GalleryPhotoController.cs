using GalleryApi.Application.DTO.Gallery;
using GalleryApi.Application.Entities;
using Microsoft.AspNetCore.Mvc;
using GalleryApi.Infrastructure.Repositories;

namespace GalleryPhoto.API.Controllers;

[Route("fotos")]
public class GalleryPhotoController : ControllerBase
{
    private readonly List<Photo> _photos;
    private readonly GeneratorFakeData _generatorFakeData;

    public GalleryPhotoController()
    {
        _photos = new List<Photo>();
        _generatorFakeData = new GeneratorFakeData();
        
        for (int i = 0; i < 5; i++)
        {
            _photos.Add(_generatorFakeData.GenerarDatosFalsosDePhoto());
            _photos[i].Id = Guid.NewGuid();
        }
    }

    [HttpGet]
    public ActionResult<GalleryResultList> GetPhotos()
    {
        return Ok(new GalleryResultList(_photos));
    }

    [HttpGet("{id}")]
    public ActionResult<GalleryResult> DownloadPhoto(Guid id)
    {
        var photo = _photos.SingleOrDefault(photo => photo.Id == id);

        if (photo is Photo p)
        {
            return Ok(new GalleryResult(p));
        }

        return NotFound();
    }
    
    [HttpGet("{userId}")]
    public ActionResult<GalleryResultList> GetPhotosByUser(Guid userId)
    {
        List<Photo> photos = _photos.Where(photo => photo.Auth.Id == userId).ToList();

        return Ok(new GalleryResultList(photos));
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

        _photos.Add(photo);

        return Ok(new GalleryResult(photo));
    }
    
    [HttpPut]
    public ActionResult<GalleryResult> UpdatePhoto(GalleryUpdateRequest request)
    {
        var photo = _photos.SingleOrDefault(photo => photo.Id == request.FileId);

        if (photo is Photo p)
        {
            int index = _photos.IndexOf(photo);

            _photos[index].FileName = request.FileName;
            _photos[index].FileDescription = request.FileDescription;

            return Ok(new GalleryResult(photo));
        }

        return NotFound();
    }
    
    [HttpDelete("fileId")]
    public ActionResult<GalleryResult> DeletePhoto(Guid fileId)
    {
        var photo = _photos.SingleOrDefault(photo => photo.Id == fileId);

        if (photo is Photo p)
        {
            int index = _photos.IndexOf(photo);
            _photos.RemoveAt(index);

            return Ok(new GalleryResult(photo));
        }

        return NotFound();
    }
}