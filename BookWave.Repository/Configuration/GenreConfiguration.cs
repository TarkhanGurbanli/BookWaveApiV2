using BookWave.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWave.Repository.Configuration;
public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        // Table configuration
        builder.ToTable("Genres");

        // Primary Key configuration
        builder.HasKey(x => x.Id);

        // Property configurations
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        // Many-to-Many relationship with Books through BookGenre
        builder.HasMany(g => g.BookGenres)
            .WithOne(bg => bg.Genre)
            .HasForeignKey(bg => bg.GenreId);
    }
}