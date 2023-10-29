using GalleryApi.Application.Common.Interfaces.Repository;
using GalleryApi.Application.DTO.Authentication;
using GalleryApi.Application.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GalleryApi.API.Controllers;

[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public AuthenticationController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("register")]
     public ActionResult<AuthenticationResult> Register(RegisterRequest request)
    {
        var user = _userRepository.GetUserByEmail(request.Email);

        Console.WriteLine(request);

        if (user is User u)
        {
            return Problem(
                statusCode: StatusCodes.Status409Conflict,
                title: "Conflict",
                detail: $"The email '{u.Email}' already exists."
            );
        }

        User newUser = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
            Photos = new List<Photo>()
        };

        _userRepository.Add(newUser);

        return Ok(new AuthenticationResult(newUser, "token"));
    }

    [HttpPost("login")]
    public ActionResult<AuthenticationResult> Login(LoginRequest request)
    {
        var user = _userRepository.GetUserByEmail(request.Email);

        if (user is not User u)
        {
            return Problem(
                statusCode: StatusCodes.Status404NotFound,
                title: "Not Found",
                detail: $"No user found with email '{request.Email}'"
            );
        }

        if (user.Password != request.Password)
        {
            return Problem(
                statusCode: StatusCodes.Status400BadRequest, 
                title: "Password incorrect."
            );
        }

        return Ok(new AuthenticationResult(user, "token"));
    }
}