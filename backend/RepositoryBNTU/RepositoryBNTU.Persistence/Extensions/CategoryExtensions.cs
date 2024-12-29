using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;

namespace RepositoryBNTU.Persistence.Extensions;

public static class CategoryExtensions
{
    public static IQueryable<Category> Filter(this IQueryable<Category> query, CategoryFilter filterModel)
    {
        if (!string.IsNullOrEmpty(filterModel.Name))
        {
            query = query.Where(c => c.Name == filterModel.Name);
        }
        
        return query;
    }
}