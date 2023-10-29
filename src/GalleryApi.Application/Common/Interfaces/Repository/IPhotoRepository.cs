using GalleryApi.Application.Entities;

namespace GalleryApi.Application.Common.Interfaces;

public interface IPhotoRepository
{
    List<Photo> GetPhotos();
    Photo? GetPhotoById(Guid id);
    List<Photo> GetPhotosByUser(Guid user);

    void Add(Photo photo);
    void Put(Photo photo);
    void Delete(Photo photo);
}