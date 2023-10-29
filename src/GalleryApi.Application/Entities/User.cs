using GalleryApi.Domain.Entities;

namespace GalleryApi.Application.Entities;

public class User : UserEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public ICollection<Photo> Photos { get; set; } = null!;
}