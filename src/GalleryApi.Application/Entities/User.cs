using GalleryApi.Domain.Entities;

namespace GalleryApi.Application.Entities;

public class User : UserEntity
{
    public User(Guid id, string firstName, string lastName, string email, string password, ICollection<Photo> photos)
    {
        base.Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Photos = photos;
    }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    ICollection<Photo> Photos { get; set; } = null!;
}