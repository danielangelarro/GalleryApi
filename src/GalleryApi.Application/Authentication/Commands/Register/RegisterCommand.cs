using ErrorOr;
using MediatR;
using GalleryApi.Application.DTO.Authentication;

namespace GalleryApi.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;