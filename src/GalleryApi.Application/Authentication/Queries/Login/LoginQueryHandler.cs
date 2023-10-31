using GalleryApi.Domain.Common.Errors;
using GalleryApi.Application.Authentication.Commands.Register;
using GalleryApi.Application.Common.Interfaces.Authentication;
using GalleryApi.Application.Common.Interfaces.Repository;
using GalleryApi.Application.Entities;
using GalleryApi.Application.DTO.Authentication;
using GalleryApi.Application.Authentication.Services;
using FluentValidation;
using ErrorOr;
using MediatR;

namespace GalleryApi.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly PasswordService _passwordService;
    private readonly IValidator<LoginQuery> _validator;

    public LoginQueryHandler(
        IUserRepository userRepository, 
        IJwtTokenGenerator jwtTokenGenerator, 
        IValidator<LoginQuery> validator,
        PasswordService passwordService)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _validator = validator;
        _passwordService = passwordService;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(query);

        if (!validationResult.IsValid)
        {
            return Errors.Model.ModelsInvalid;
        }

        if (await _userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (!_passwordService.VerifyPassword(query.Password, user.Password))
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        Console.WriteLine($"Login: {token}");

        return new AuthenticationResult(
            user,
            token
        );
    }
}