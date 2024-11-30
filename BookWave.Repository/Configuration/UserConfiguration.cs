using BookWave.Entity.Entities;
using BookWave.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWave.Repository.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

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
            .IsRequired();

        builder.Property(u => u.Role)
       .HasConversion(
           r => r.ToString(),
           r => (Role)Enum.Parse(typeof(Role), r)
       );

        // One-to-One relationship with Image
        builder.HasOne(u => u.Image)
            .WithOne()
            .HasForeignKey<User>(u => u.ImageId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many relationship with Comments
        builder.HasMany(u => u.Comments)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many relationship with Wishlists
        builder.HasMany(u => u.Wishlists)
            .WithOne(w => w.User)
            .HasForeignKey(w => w.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many relationship with Favorites
        builder.HasMany(u => u.Favorites)
            .WithOne(f => f.User)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // One-to-Many relationship with Blogs
        builder.HasMany(u => u.Blogs)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}