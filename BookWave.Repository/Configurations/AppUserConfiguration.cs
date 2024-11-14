using BookWave.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWave.Repository.Configurations;
public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable("AppUsers");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Username).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Email)
          .IsRequired()
          .HasMaxLength(100);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(u => u.PasswordSalt)
           .IsRequired()
           .HasMaxLength(200);

        builder.Property(u => u.Role)
           .IsRequired()
           .HasConversion<int>();

        // One-to-One relationship with Image
        builder.HasOne(u => u.Image)
            .WithOne()
            .HasForeignKey<AppUser>(u => u.ImageId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many relationship with Comments
        builder.HasMany(u => u.Comments)
            .WithOne(c => c.AppUser)
            .HasForeignKey(c => c.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many relationship with Wishlists
        builder.HasMany(u => u.Wishlists)
            .WithOne(w => w.AppUser)
            .HasForeignKey(w => w.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many relationship with Favorites
        builder.HasMany(u => u.Favorites)
            .WithOne(f => f.AppUser)
            .HasForeignKey(f => f.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many relationship with Blogs
        builder.HasMany(u => u.Blogs)
            .WithOne(b => b.AppUser)
            .HasForeignKey(b => b.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}