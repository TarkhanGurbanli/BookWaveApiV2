using BookWave.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWave.Repository.Configuration;
public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
{
    public void Configure(EntityTypeBuilder<Quote> builder)
    {
        // Table configuration
        builder.ToTable("Quotes");

        // Primary Key configuration
        builder.HasKey(q => q.Id);

        // Properties configuration
        builder.Property(q => q.Text)
            .IsRequired()
            .HasMaxLength(500);

        // Relationship with Author
        builder.HasOne(q => q.Author)
            .WithMany(a => a.Quotes)
            .HasForeignKey(q => q.AuthorId)
            .OnDelete(DeleteBehavior.NoAction);

        // Relationship with Book
        builder.HasOne(q => q.Book)
            .WithMany(b => b.Quotes)
            .HasForeignKey(q => q.BookId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}