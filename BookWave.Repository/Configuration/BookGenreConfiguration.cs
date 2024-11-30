using BookWave.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWave.Repository.Configuration;
public class BookGenreConfiguration : IEntityTypeConfiguration<BookGenre>
{
    public void Configure(EntityTypeBuilder<BookGenre> builder)
    {
        // Table configuration
        builder.ToTable("BookGenres");

        // Composite Key configuration for Many-to-Many relationship
        builder.HasKey(bg => new { bg.BookId, bg.GenreId });

        // Foreign key configuration for Book
        builder.HasOne(bg => bg.Book)
            .WithMany(b => b.BookGenres)
            .HasForeignKey(bg => bg.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        // Foreign key configuration for Genre
        builder.HasOne(bg => bg.Genre)
            .WithMany(g => g.BookGenres)
            .HasForeignKey(bg => bg.GenreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}