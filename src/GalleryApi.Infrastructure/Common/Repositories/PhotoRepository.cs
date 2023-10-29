using GalleryApi.Application.Common.Interfaces;
using GalleryApi.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace GalleryApi.Infrastructure.Repositories;

public class PhotoRepository : IPhotoRepository
{
    private readonly GalleryPhotoDBContext _context;

    public PhotoRepository(GalleryPhotoDBContext context)
    {
        _context = context;
    }

    public async void Add(Photo photo)
    {
        _context.Photos.Add(photo);
        await _context.SaveChangesAsync();
    }

    public async void Delete(Photo photo)
    {
        _context.Photos.Remove(photo);
        await _context.SaveChangesAsync();
    }

    public async void Put(Photo photo)
    {
        _context.Entry(photo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<Photo?> GetPhotoById(Guid id)
    {
        return await _context.Photos.SingleOrDefaultAsync(photo => photo.Id == id);
    }

    public async Task<List<Photo>> GetPhotos()
    {
        return await _context.Photos.ToListAsync();
    }

    public async Task<List<Photo>> GetPhotosByUser(Guid userId)
    {
        return await _context.Photos.Where(user => user.Id == userId).ToListAsync();
    }
}