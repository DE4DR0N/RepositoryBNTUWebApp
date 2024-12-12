using RepositoryBNTU.Domain.Abstractions;
using RepositoryBNTU.Persistence.Repositories;

namespace RepositoryBNTU.Persistence;

public class UnitOfWork(RepositoryDbContext context) : IUnitOfWork
{
    private AuthorRepository _authorRepository;
    private PublicationRepository _publicationRepository;
    private UserRepository _userRepository;

    public IAuthorRepository Authors => _authorRepository ??= new AuthorRepository(context);
    public IPublicationRepository Publications => _publicationRepository ??= new PublicationRepository(context);
    public IUserRepository Users => _userRepository ??= new UserRepository(context);

    public void Dispose()
    {
        context.Dispose();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}