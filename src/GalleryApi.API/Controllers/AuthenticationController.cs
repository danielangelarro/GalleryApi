using GalleryApi.Application.DTO.Authentication;
using GalleryApi.Application.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GalleryApi.API.Controllers;

[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly List<User> _users;

    public AuthenticationController()
    {
        _users = new List<User>();
    }

    [HttpPost("register")]
     public ActionResult<AuthenticationResult> Register(RegisterRequest request)
    {
        if (_users.SingleOrDefault(user => user.Email == request.Email) is not null)
        {
           return NotFound();
        }

        User user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
            Photos = new List<Photo>()
        };

        _users.Add(user);

        return Ok(new AuthenticationResult(user, "token"));
    }

    [HttpPost("login")]
    public ActionResult<AuthenticationResult> Login(LoginRequest request)
    {
        var user = _users.SingleOrDefault(user => user.Email == request.Email);
        
        if (user is not User _user)
        {
            return Problem(
                statusCode: StatusCodes.Status404NotFound, 
                detail: "User not found."
            );
        }

        if (user.Password != request.Password)
        {
            return Problem(
                statusCode: StatusCodes.Status400BadRequest, 
                detail: "Password incorrect."
            );
        }

        return Ok(new AuthenticationResult(user, "token"));
    }
}