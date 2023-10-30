using GalleryApi.Application.Common.Interfaces.Repository;
using GalleryApi.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace GalleryApi.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public readonly GalleryPhotoDBContext _context;

    public UserRepository(GalleryPhotoDBContext context)
    {
        _context = context;
    }

    public async void Add(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _context.Users.SingleOrDefaultAsync(user => user.Email == email);
    }
}