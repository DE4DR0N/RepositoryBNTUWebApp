using Microsoft.EntityFrameworkCore;
using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.Persistence;

public class RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publication> Publications { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>(author =>
        {
            author.HasKey(a => a.Id);
            author.Property(a => a.FirstName).HasMaxLength(50);
            author.Property(a => a.LastName).HasMaxLength(50);
            author.HasMany(a => a.Publications)
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId);
        });

        modelBuilder.Entity<Publication>(publication =>
        {
            publication.HasKey(p => p.Id);
            publication.HasIndex(p => p.Title).IsUnique();
            publication.HasIndex(p => p.ISBN).IsUnique();
            publication.Property(p => p.Title).HasMaxLength(100);
            publication.Property(p => p.Description).HasMaxLength(500);
            publication.HasMany(p => p.UsersFavoriteBy)
                .WithMany(u => u.FavoritePublications);
        });

        modelBuilder.Entity<Category>(category =>
        {
            category.HasKey(c => c.Id);
            category.HasIndex(c => c.Name).IsUnique();
            category.Property(c => c.Name).HasMaxLength(100);
            category.HasMany(c => c.Publications)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
        });

        modelBuilder.Entity<User>(user =>
        {
            user.HasKey(u => u.Id);
            user.HasIndex(u => u.Email).IsUnique();
            user.Property(u => u.Email).IsRequired();
            user.Property(u => u.PasswordHash).IsRequired();
            user.Property(u => u.Role).IsRequired();
        });
    }
}