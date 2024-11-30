using BookWave.Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookWave.Repository.Configuration;
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

        // Foreign key configuration for User (One-to-Many relationship)
        builder.HasOne(b => b.User)
            .WithMany(u => u.Blogs)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many relationship with Comments
        builder.HasMany(b => b.Comments)
            .WithOne(c => c.Blog)
            .HasForeignKey(c => c.BlogId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}