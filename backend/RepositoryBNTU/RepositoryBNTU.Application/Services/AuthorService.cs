using RepositoryBNTU.Application.Abstractions;
using RepositoryBNTU.Domain.Abstractions;
using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;

namespace RepositoryBNTU.Application.Services;

public class AuthorService : IAuthorService
{
    private readonly IUnitOfWork _unitOfWork;

    public AuthorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Author?> GetByIdAsync(Guid id)
    {
        var author = await _unitOfWork.Authors.GetByIdAsync(id);
        if (author == null) throw new KeyNotFoundException("Author not found");
        return author;
    }

    public async Task<IEnumerable<Author>> GetAllAsync(AuthorFilter filter)
    {
        var authors = await _unitOfWork.Authors.GetAllAsync(filter);
        return authors;
    }

    public async Task CreateAsync(Author entity)
    {
        await _unitOfWork.Authors.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Author entity)
    {
        var author = await _unitOfWork.Authors.GetByIdAsync(entity.Id);
        if (author == null) throw new KeyNotFoundException("Author not found");
        
        _unitOfWork.Authors.Update(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var author = await _unitOfWork.Authors.GetByIdAsync(id);
        if (author == null) throw new KeyNotFoundException("Author not found");
        
        _unitOfWork.Authors.Delete(author);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<Publication>> GetPublicationsByAuthorAsync(Guid authorId)
    {
        var author = await _unitOfWork.Authors.GetByIdAsync(authorId);
        if (author == null) throw new KeyNotFoundException("Author not found");
        
        var publications = await _unitOfWork.Authors.GetPublicationsByAuthorAsync(authorId);
        return publications;
    }
}