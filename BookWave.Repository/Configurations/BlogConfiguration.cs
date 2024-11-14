using BookWave.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWave.Repository.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        // Table configuration
        builder.ToTable("Blogs");

        // Primary Key configuration
        builder.HasKey(x => x.Id);

        // Property configurations
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Content)
            .IsRequired()
            .HasMaxLength(1500);

        // Foreign key configuration for AppUser (One-to-Many relationship)
        builder.HasOne(b => b.AppUser)
            .WithMany(u => u.Blogs)
            .HasForeignKey(b => b.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many relationship with Comments
        builder.HasMany(b => b.Comments)
            .WithOne(c => c.Blog)
            .HasForeignKey(c => c.BlogId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}