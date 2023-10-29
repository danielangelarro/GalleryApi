using GalleryApi.Domain.Common.Errors;
using GalleryApi.Application.Authentication.Commands.Register;
using GalleryApi.Application.Common.Interfaces.Authentication;
using GalleryApi.Application.Common.Interfaces.Repository;
using GalleryApi.Application.Entities;
using GalleryApi.Application.DTO.Authentication;
using ErrorOr;
using MediatR;

namespace GalleryApi.Application.Authentication.Commands.Register;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}