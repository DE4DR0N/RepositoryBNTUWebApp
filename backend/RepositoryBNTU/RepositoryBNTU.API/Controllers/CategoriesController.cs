using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryBNTU.API.DTOs.CategoryDTOs;
using RepositoryBNTU.Application.Abstractions;
using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICategoryService _categoryService;

    public CategoriesController(IMapper mapper, ICategoryService categoryService)
    {
        _mapper = mapper;
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _categoryService.GetAllAsync();
        var categoryViewModels = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
        
        return Ok(categoryViewModels);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
    {
        var category = await _categoryService.GetByIdAsync(id);
        var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
        
        return Ok(categoryViewModel);
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var category = _mapper.Map<Category>(model);
        await _categoryService.CreateAsync(category);
        
        return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCategory([FromRoute]Guid id, [FromBody]CategoryUpdateViewModel model)
    {
        if (!ModelState.IsValid || id != model.Id)
        {
            return BadRequest(ModelState);
        }
        var category = _mapper.Map<Category>(model);
        await _categoryService.UpdateAsync(category);
        
        return Ok("Category updated");
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
    {
        await _categoryService.DeleteAsync(id);
        
        return NoContent();
    }
}