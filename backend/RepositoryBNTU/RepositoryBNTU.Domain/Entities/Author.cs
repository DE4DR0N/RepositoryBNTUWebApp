namespace RepositoryBNTU.Domain.Entities;

public class Author
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public virtual ICollection<Publication> Publications { get; set; } = new List<Publication>();
}