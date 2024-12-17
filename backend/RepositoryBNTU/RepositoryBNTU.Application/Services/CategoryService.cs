using RepositoryBNTU.Application.Abstractions;
using RepositoryBNTU.Domain.Abstractions;
using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id);
        if (category == null) throw new KeyNotFoundException("Category not found");
        return category;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        var categories = await _unitOfWork.Categories.GetAllAsync();
        return categories;
    }

    public async Task CreateAsync(Category entity)
    {
        await _unitOfWork.Categories.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category entity)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(entity.Id);
        if (category == null) throw new KeyNotFoundException("Category not found");
        var categoryToUpdate = await _unitOfWork.Categories.GetCategoryByNameAsync(entity.Name);
        if (categoryToUpdate != null) throw new Exception($"Conflict: Category {entity.Name} already exists");
        
        _unitOfWork.Categories.Update(category);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id);
        if (category == null) throw new KeyNotFoundException("Category not found");
        _unitOfWork.Categories.Delete(category);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<Category?> GetCategoryByNameAsync(string name)
    {
        var category = await _unitOfWork.Categories.GetCategoryByNameAsync(name);
        if (category == null) throw new KeyNotFoundException("Category not found");
        return category;
    }
}