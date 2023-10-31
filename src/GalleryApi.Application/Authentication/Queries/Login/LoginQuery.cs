using ErrorOr;
using MediatR;
using GalleryApi.Application.DTO.Authentication;

namespace GalleryApi.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;