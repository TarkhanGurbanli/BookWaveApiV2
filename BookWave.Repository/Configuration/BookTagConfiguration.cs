using BookWave.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWave.Repository.Configuration;
public class BookTagConfiguration : IEntityTypeConfiguration<BookTag>
{
    public void Configure(EntityTypeBuilder<BookTag> builder)
    {
        // Table configuration
        builder.ToTable("BookTags");

        // Composite Key configuration for Many-to-Many relationship
        builder.HasKey(bg => new { bg.BookId, bg.TagId });

        // Foreign key configuration for Book
        builder.HasOne(bg => bg.Book)
            .WithMany(b => b.BookTags)
            .HasForeignKey(bg => bg.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        // Foreign key configuration for Tag
        builder.HasOne(bg => bg.Tag)
            .WithMany(g => g.BookTags)
            .HasForeignKey(bg => bg.TagId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
