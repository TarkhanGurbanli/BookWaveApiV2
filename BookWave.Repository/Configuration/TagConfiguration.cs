using BookWave.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWave.Repository.Configuration;
public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        // Table configuration
        builder.ToTable("Tags");

        // Primary Key configuration
        builder.HasKey(x => x.Id);

        // Property configurations
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        // Many-to-Many relationship with Books through BookGenre
        builder.HasMany(g => g.BookTags)
            .WithOne(bg => bg.Tag)
            .HasForeignKey(bg => bg.BookId);
    }
}
