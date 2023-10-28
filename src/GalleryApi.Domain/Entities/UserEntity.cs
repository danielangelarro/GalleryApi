using System.ComponentModel.DataAnnotations;

namespace GalleryApi.Domain.Entities;

public class UserEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}