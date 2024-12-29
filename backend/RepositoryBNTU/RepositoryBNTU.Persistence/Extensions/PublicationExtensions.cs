using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;

namespace RepositoryBNTU.Persistence.Extensions;

public static class PublicationExtensions
{
    public static IQueryable<Publication> Filter(this IQueryable<Publication> query, PublicationFilter filterModel)
    {
        if (!string.IsNullOrEmpty(filterModel.Title))
        {
            query = query.Where(p => p.Title == filterModel.Title);
        }

        if (!string.IsNullOrEmpty(filterModel.ISBN))
        {
            query = query.Where(p => p.ISBN == filterModel.ISBN);
        }
        
        return query;
    }

    public static IQueryable<Publication> Paginate(this IQueryable<Publication> query, int? pageNumber, int? pageSize)
    {
        var page = pageNumber ?? 1;
        var size = pageSize ?? 10;
        
        return query.Skip((page - 1) * size).Take(size);
    }
}