using BookWave.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWave.Repository.Configuration;
public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        // Table configuration
        builder.ToTable("Books");

        // Primary Key configuration
        builder.HasKey(x => x.Id);

        // Property configurations
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(x => x.ImageUrl)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Rating)
            .IsRequired()
            .HasPrecision(3, 2);

        // Foreign key configuration for Author (One-to-Many relationship)
        builder.HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        // Foreign key configuration for Publisher (One-to-Many relationship)
        builder.HasOne(b => b.Publisher)
            .WithMany(p => p.Books)
            .HasForeignKey(b => b.PublisherId)
            .OnDelete(DeleteBehavior.Cascade);

        // Many-to-Many relationship with Genre through BookGenre (join table)
        builder.HasMany(b => b.BookGenres)
            .WithOne(bg => bg.Book)
            .HasForeignKey(bg => bg.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many relationship with Comments
        builder.HasMany(b => b.Comments)
            .WithOne(c => c.Book)
            .HasForeignKey(c => c.BookId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}