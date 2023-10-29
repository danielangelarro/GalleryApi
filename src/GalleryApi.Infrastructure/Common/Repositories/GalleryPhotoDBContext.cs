using GalleryApi.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace GalleryApi.Infrastructure.Repositories;

public class GalleryPhotoDBContext : DbContext
{
    public GalleryPhotoDBContext(DbContextOptions<GalleryPhotoDBContext> options) : base(options)
    {
    }

    public DbSet<User> Users {get; set; }
    public DbSet<Photo> Photos {get; set; }
}