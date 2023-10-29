using GalleryApi.Domain.Entities;

namespace GalleryApi.Application.Entities;

public class Photo : Entity
{
    public string FileDescription { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public byte[] Contenido { get; set; } = null!;

    public User Auth { get; set; } = null!;
}