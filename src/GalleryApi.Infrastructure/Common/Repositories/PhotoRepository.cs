using GalleryApi.Application.Common.Interfaces;
using GalleryApi.Application.Entities;

namespace GalleryApi.Infrastructure.Repositories;

public class PhotoRepository : IPhotoRepository
{
    private static readonly List<Photo> _photos = new();

    public void Add(Photo photo)
    {
        _photos.Add(photo);
    }

    public void Delete(Photo photo)
    {
        _photos.Remove(photo);
    }

    public void Put(Photo photo)
    {
        int index = _photos.IndexOf(photo);

        if (index != -1)
        {
            _photos[index].FileName = photo.FileName;
            _photos[index].FileDescription = photo.FileDescription;
        }
    }

    public Photo? GetPhotoById(Guid id)
    {
        return _photos.SingleOrDefault(photo => photo.Id == id);
    }

    public List<Photo> GetPhotos()
    {
        return _photos;
    }

    public List<Photo> GetPhotosByUser(Guid userId)
    {
        return _photos.Where(user => user.Id == userId).ToList();
    }
}