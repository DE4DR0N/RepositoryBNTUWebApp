using RepositoryBNTU.Application.Abstractions;
using RepositoryBNTU.Domain.Abstractions;
using RepositoryBNTU.Domain.Entities;

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

    public async Task<IEnumerable<Publication>> GetAllAsync() // ПАГИНАЦИЯ
    {
        var publications = await _unitOfWork.Publications.GetAllAsync();
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
        if (publicationToUpdate != null) throw new Exception($"Publication with ISBN {entity.ISBN} already exists");
        
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
}