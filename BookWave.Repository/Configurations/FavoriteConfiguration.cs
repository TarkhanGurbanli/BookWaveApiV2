using BookWave.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWave.Repository.Configurations;

public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
{
    public void Configure(EntityTypeBuilder<Favorite> builder)
    {
        // Table configuration
        builder.ToTable("Favorites");

        // Composite primary key configuration
        builder.HasKey(f => new { f.AppUserId, f.BookId });

        // Relationship with AppUser
        builder.HasOne(f => f.AppUser)
            .WithMany(u => u.Favorites)
            .HasForeignKey(f => f.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relationship with Book
        builder.HasOne(f => f.Book)
            .WithMany(b => b.Favorites)
            .HasForeignKey(f => f.BookId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}