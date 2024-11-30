using BookWave.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWave.Repository.Configuration;
public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        // Table configuration
        builder.ToTable("Publishers");

        // Primary Key configuration
        builder.HasKey(p => p.Id);

        // Properties configuration
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Relationship with Book
        builder.HasMany(p => p.Books)
            .WithOne(b => b.Publisher)
            .HasForeignKey(b => b.PublisherId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}