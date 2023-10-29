using GalleryApi.Application.Entities;

namespace GalleryApi.Application.Common.Interfaces;

public interface IPhotoRepository
{
    Task<List<Photo>> GetPhotos();
    Task<Photo?> GetPhotoById(Guid id);
    Task<List<Photo>> GetPhotosByUser(Guid user);

    void Add(Photo photo);
    void Put(Photo photo);
    void Delete(Photo photo);
}