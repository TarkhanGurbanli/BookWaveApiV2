using BookWave.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWave.Repository.Configuration;
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Table configuration
        builder.ToTable("Categories");

        // Primary Key configuration
        builder.HasKey(x => x.Id);

        // Property configurations
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        // Many-to-Many relationship with Books through BookGenre
        builder.HasMany(g => g.BookCategories)
            .WithOne(bg => bg.Category)
            .HasForeignKey(bg => bg.CategoryId);
    }
}