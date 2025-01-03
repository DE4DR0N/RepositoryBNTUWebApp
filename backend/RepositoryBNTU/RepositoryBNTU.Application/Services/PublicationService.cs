﻿using RepositoryBNTU.Application.Abstractions;
using RepositoryBNTU.Domain.Abstractions;
using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;

namespace RepositoryBNTU.Application.Services;

public class PublicationService : IPublicationService
{
    private readonly IUnitOfWork _unitOfWork;

    public PublicationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Publication?> GetByIdAsync(Guid id)
    {
        var publication = await _unitOfWork.Publications.GetByIdAsync(id);
        if (publication == null) throw new KeyNotFoundException();
        return publication;
    }
    
    public async Task<IEnumerable<Publication>> GetAllAsync(PublicationFilter filter)
    {
        var publications = await _unitOfWork.Publications.GetAllAsync(filter);
        return publications;
    }
    
    public async Task<(IEnumerable<Publication> publications, int totalPages)> GetAllAsync(PublicationFilter filter, int? page, int? pageSize)
    {
        var publications = await _unitOfWork.Publications.GetAllAsync(filter, page, pageSize);
        return publications;
    }

    public async Task CreateAsync(Publication entity)
    {
        await _unitOfWork.Publications.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Publication entity)
    {
        var publication = await _unitOfWork.Publications.GetByIdAsync(entity.Id);
        if (publication == null) throw new KeyNotFoundException("Publication not found");

        var publicationToUpdate = await _unitOfWork.Publications.GetPublicationByIsbnAsync(entity.ISBN);
        if (publicationToUpdate != null && publicationToUpdate.Id != publication.Id) throw new Exception($"Conflict: Publication with ISBN {entity.ISBN} already exists");
        
        _unitOfWork.Publications.Update(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var publication = await _unitOfWork.Publications.GetByIdAsync(id);
        if (publication == null) throw new KeyNotFoundException("Publication not found");
        _unitOfWork.Publications.Delete(publication);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<Publication?> GetPublicationByIsbnAsync(string isbn)
    {
        var publication = await _unitOfWork.Publications.GetPublicationByIsbnAsync(isbn);
        if (publication == null) throw new KeyNotFoundException("Publication not found");
        return publication;
    }

    public async Task<IEnumerable<Publication>> GetPublicationsByCategoryAsync(Guid categoryId)
    {
        var publications = await _unitOfWork.Publications.GetPublicationsByCategoryAsync(categoryId);
        return publications;
    }

    public async Task<IEnumerable<Publication>> SearchAsync(string searchTerm)
    {
        var publications = await _unitOfWork.Publications.SearchAsync(searchTerm);
        return publications;
    }
}