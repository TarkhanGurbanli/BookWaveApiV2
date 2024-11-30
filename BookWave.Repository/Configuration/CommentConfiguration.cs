using BookWave.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWave.Repository.Configuration;
public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        // Table configuration
        builder.ToTable("Comments");

        // Primary Key
        builder.HasKey(x => x.Id);

        // Property configurations
        builder.Property(x => x.Text)
            .IsRequired()
            .HasMaxLength(500);

        // Relationship with AppUser
        builder.HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        // Optional relationship with Book
        builder.HasOne(c => c.Book)
            .WithMany(b => b.Comments)
            .HasForeignKey(c => c.BookId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false); // Allow Comment to exist without Book

        // Optional relationship with Blog
        builder.HasOne(c => c.Blog)
            .WithMany(b => b.Comments)
            .HasForeignKey(c => c.BlogId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false); // Allow Comment to exist without Blog
    }
}