namespace RepositoryBNTU.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string Role { get; set; }
    public virtual ICollection<Publication> FavoritePublications { get; set; } = new List<Publication>();
}