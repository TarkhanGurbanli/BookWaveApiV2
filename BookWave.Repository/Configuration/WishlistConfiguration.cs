using BookWave.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWave.Repository.Configuration;
public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
{
    public void Configure(EntityTypeBuilder<Wishlist> builder)
    {
        // Table name configuration
        builder.ToTable("Wishlists");

        // Primary Key configuration
        builder.HasKey(w => w.Id);

        // Foreign Key configuration for AppUser
        builder.HasOne(w => w.User)
            .WithMany(a => a.Wishlists)
            .HasForeignKey(w => w.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Foreign Key configuration for Book
        builder.HasOne(w => w.Book)
            .WithMany(b => b.Wishlists)
            .HasForeignKey(w => w.BookId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}