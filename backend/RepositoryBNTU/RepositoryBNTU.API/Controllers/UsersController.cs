using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryBNTU.API.DTOs.PublicationDTOs;
using RepositoryBNTU.API.DTOs.UserDTOs;
using RepositoryBNTU.Application.Abstractions;
using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;

namespace RepositoryBNTU.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers([FromQuery] UserFilter filter)
    {
        var users = await _userService.GetAllAsync(filter);
        var userViewModels = _mapper.Map<IEnumerable<UserViewModel>>(users);
        
        return Ok(userViewModels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] Guid id)
    {
        var user = await _userService.GetByIdAsync(id);
        var userViewModel = _mapper.Map<UserViewModel>(user);
        
        return Ok(userViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user = _mapper.Map<User>(model);
        await _userService.CreateAsync(user);
        
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UserUpdateViewModel model)
    {
        if (!ModelState.IsValid || id != model.Id)
        {
            return BadRequest(ModelState);
        }
        var user = _mapper.Map<User>(model);
        await _userService.UpdateAsync(user); 
        
        return Ok("User updated");
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
    {
        await _userService.DeleteAsync(id);
        
        return NoContent();
    }

    [HttpGet("{id:guid}/publications")]
    public async Task<IActionResult> GetPublicationsByUser([FromRoute] Guid id)
    {
        var publications = await _userService.GetPublicationsByUserAsync(id);
        var publicationViewModels = _mapper.Map<IEnumerable<PublicationViewModel>>(publications);
        
        return Ok(publicationViewModels);
    }
}