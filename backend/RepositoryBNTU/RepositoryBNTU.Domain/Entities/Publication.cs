namespace RepositoryBNTU.Domain.Entities;

public class Publication
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string ISBN { get; set; }
    public DateOnly PublishDate { get; set; }
    public Guid CategoryId { get; set; }
    public Guid AuthorId { get; set; }
    
    public virtual required Author Author { get; set; }
    public virtual required Category Category { get; set; }
    public virtual ICollection<User> UsersFavoriteBy { get; set; } = new List<User>();
}