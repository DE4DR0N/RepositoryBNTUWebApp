using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepositoryBNTU.API.DTOs.AuthorizationDTOs;
using RepositoryBNTU.Application.Abstractions;
using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAuthorizationService _authorizationService;
    private readonly IConfiguration _configuration;

    public AuthController(IAuthorizationService authorizationService, IMapper mapper, IConfiguration configuration)
    {
        _authorizationService = authorizationService;
        _mapper = mapper;
        _configuration = configuration;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] AuthorizationViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user = _mapper.Map<User>(model);
        await _authorizationService.RegisterAsync(user);
        
        return Ok("User created");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] AuthorizationViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user = _mapper.Map<User>(model);
        var accessToken = await _authorizationService.LoginAsync(user);
        
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["DurationInMinutes"]))
        };
        
        HttpContext.Response.Cookies.Append("accessToken", accessToken, cookieOptions);

        return Ok(new { token = accessToken });
    }
}