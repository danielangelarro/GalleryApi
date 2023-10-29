using GalleryApi.Application.Entities;

namespace GalleryApi.Application.Common.Interfaces.Repository;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    void Add(User user);
}