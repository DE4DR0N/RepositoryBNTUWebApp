using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;

namespace RepositoryBNTU.Persistence.Extensions;

public static class AuthorExtensions
{
    public static IQueryable<Author> Filter(this IQueryable<Author> query, AuthorFilter filterModel)
    {
        if (!string.IsNullOrEmpty(filterModel.FirstName))
        {
            query = query.Where(a => a.FirstName == filterModel.FirstName);
        }

        if (!string.IsNullOrEmpty(filterModel.LastName))
        {
            query = query.Where(a => a.LastName == filterModel.LastName);
        }
        
        return query;
    }
}