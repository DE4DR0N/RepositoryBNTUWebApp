using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryBNTU.API.DTOs.AuthorDTOs;
using RepositoryBNTU.Application.Abstractions;
using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;

namespace RepositoryBNTU.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;

    public AuthorsController(IMapper mapper, IAuthorService authorService)
    {
        _mapper = mapper;
        _authorService = authorService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAuthors([FromQuery] AuthorFilter filter)
    {
        var authors = await _authorService.GetAllAsync(filter);
        var authorsViewModel = _mapper.Map<IEnumerable<AuthorViewModel>>(authors);
        
        return Ok(authorsViewModel);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthorById([FromRoute] Guid id)
    {
        var author = await _authorService.GetByIdAsync(id);
        var authorViewModel = _mapper.Map<AuthorViewModel>(author);
        
        return Ok(authorViewModel);
    }
    
    [Authorize(Policy = "AdminOnly")]
    [HttpPost]
    public async Task<IActionResult> CreateAuthor([FromBody] AuthorCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var author = _mapper.Map<Author>(model);
        await _authorService.CreateAsync(author);
        
        return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, author);
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAuthor([FromRoute] Guid id, [FromBody] AuthorUpdateViewModel model)
    {
        if (!ModelState.IsValid || id != model.Id)
        {
            return BadRequest(ModelState);
        }
        var author = _mapper.Map<Author>(model);
        await _authorService.UpdateAsync(author);
        
        return Ok("Author updated successfully.");
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAuthor([FromRoute] Guid id)
    {
        await _authorService.DeleteAsync(id);
        
        return NoContent();
    }
}