using BookWave.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWave.Repository.Configuration;
public class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
{
    public void Configure(EntityTypeBuilder<BookCategory> builder)
    {
        // Table configuration
        builder.ToTable("BookCategories");

        // Composite Key configuration for Many-to-Many relationship
        builder.HasKey(bg => new { bg.BookId, bg.CategoryId });

        // Foreign key configuration for Book
        builder.HasOne(bg => bg.Book)
            .WithMany(b => b.BookCategories)
            .HasForeignKey(bg => bg.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        // Foreign key configuration for Category
        builder.HasOne(bg => bg.Category)
            .WithMany(g => g.BookCategories)
            .HasForeignKey(bg => bg.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}