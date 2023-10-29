namespace GalleryApi.Application.DTO.Authentication;

public record LoginRequest(
    string Email,
    string Password);