using BookWave.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWave.Repository.Configuration;
public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        // Table configuration
        builder.ToTable("Authors");

        // Primary Key configuration
        builder.HasKey(x => x.Id);

        // Property configurations
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Nationality)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Biography)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(x => x.ImageUrl)
            .IsRequired()
            .HasMaxLength(100);

        // One-to-Many relationship with Books
        builder.HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}