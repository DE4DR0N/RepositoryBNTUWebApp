﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepositoryBNTU.API.DTOs.PublicationDTOs;
using RepositoryBNTU.Application.Abstractions;
using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublicationsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPublicationService _publicationService;

    public PublicationsController(IMapper mapper, IPublicationService publicationService)
    {
        _mapper = mapper;
        _publicationService = publicationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPublications()
    {
        var publications = await _publicationService.GetAllAsync();
        var publicationViewModels = _mapper.Map<IEnumerable<PublicationViewModel>>(publications);
        
        return Ok(publicationViewModels);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPublicationById([FromRoute] Guid id)
    {
        var publication = await _publicationService.GetByIdAsync(id);
        var publicationViewModel = _mapper.Map<PublicationViewModel>(publication);
        
        return Ok(publicationViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePublication([FromBody] PublicationCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var publication = _mapper.Map<Publication>(model);
        await _publicationService.CreateAsync(publication);
        
        return CreatedAtAction(nameof(GetPublicationById), new {id = publication.Id}, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdatePublication([FromRoute] Guid id, [FromBody] PublicationUpdateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var publication = _mapper.Map<Publication>(model);
        await _publicationService.UpdateAsync(publication);
        
        return Ok("Publication updated");
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePublication([FromRoute] Guid id)
    {
        await _publicationService.DeleteAsync(id);
        
        return NoContent();
    }
}