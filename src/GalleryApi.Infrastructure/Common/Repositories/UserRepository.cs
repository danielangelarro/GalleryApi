using GalleryApi.Application.Common.Interfaces.Repository;
using GalleryApi.Application.Entities;

namespace GalleryApi.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.Find(u => u.Email == email);
    }
}