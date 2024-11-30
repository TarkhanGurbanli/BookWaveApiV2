using BookWave.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookWave.Repository.Context;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Author> Author { get; set; } = default!;
    public DbSet<Blog> Blogs { get; set; } = default!;
    public DbSet<Book> Books { get; set; } = default!;
    public DbSet<BookGenre> BookGenres { get; set; } = default!;
    public DbSet<Comment> Comments { get; set; } = default!;
    public DbSet<Favorite> Favorites { get; set; } = default!;
    public DbSet<Genre> Genres { get; set; } = default!;
    public DbSet<PhotoFile> PhotoFiles { get; set; } = default!;
    public DbSet<Publisher> Publishers { get; set; } = default!;
    public DbSet<Quote> Quotes { get; set; } = default!;
    public DbSet<Wishlist> Wishlists { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}