namespace RepositoryBNTU.Domain.Entities;

public class Category
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public virtual ICollection<Publication> Publications { get; set; } = new List<Publication>();
}