using GalleryApi.Application.Entities;

namespace GalleryApi.Application.DTO.Authentication;

public record AuthenticationResult(User user, string Token);