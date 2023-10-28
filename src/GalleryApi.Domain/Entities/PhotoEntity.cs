using System.ComponentModel.DataAnnotations;

namespace GalleryApi.Domain.Entities;

public class PhotoEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}