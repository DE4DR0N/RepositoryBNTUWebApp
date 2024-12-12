namespace RepositoryBNTU.Domain.Abstractions;

public interface IUnitOfWork : IDisposable
{
    IPublicationRepository Publications { get; }
    IAuthorRepository Authors { get; }
    IUserRepository Users { get; }
    Task<int> SaveChangesAsync();
}