using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for the users
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly LibraryContext _context;

    public UsersController(LibraryContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public ActionResult<User> Register([FromBody] User user) // I want to later add Login and Register functionality
        // And only allow Logined users to be able to reserve the books
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return Ok(user);
    }

    [HttpPost("login")]
    public ActionResult<User> Login([FromBody] LoginRequest request)
    {
        var user = _context.Users.FirstOrDefault(u => u.UserName == request.Username && u.Password == request.Password);
        if (user == null)
        {
            return Unauthorized();
        }
        return Ok(user);
    }
}

public class LoginRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}

