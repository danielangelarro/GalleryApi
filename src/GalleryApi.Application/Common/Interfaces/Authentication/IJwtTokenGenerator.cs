using GalleryApi.Application.Entities;

namespace GalleryApi.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}