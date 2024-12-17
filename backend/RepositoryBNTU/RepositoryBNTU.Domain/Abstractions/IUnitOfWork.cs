namespace RepositoryBNTU.Domain.Abstractions;

public interface IUnitOfWork : IDisposable
{
    IPublicationRepository Publications { get; }
    IAuthorRepository Authors { get; }
    IUserRepository Users { get; }
    ICategoryRepository Categories { get; }
    Task<int> SaveChangesAsync();
}