using BookWave.Entity.Base;
using BookWave.Entity.Enums;

namespace BookWave.Entity.Entities;
public class AppUser : BaseEntity
{
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string PasswordSalt { get; set; } = default!;
    public Role Role { get; set; }
    public int ImageId { get; set; }
    public Image? Image { get; set; }
    public List<Comment>? Comments { get; set; }
    public List<Wishlist>? Wishlists { get; set; }
    public List<Favorite>? Favorites { get; set; }
    public List<Blog>? Blogs { get; set; }
}