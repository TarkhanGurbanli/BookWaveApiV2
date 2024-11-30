using BookWave.Entity.Base;
using BookWave.Entity.Enums;

namespace BookWave.Entity.Entities;
public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = default!;
    public Role Role { get; set; }
    public int? ImageId { get; set; }
    public PhotoFile? Image { get; set; }
    public List<Comment>? Comments { get; set; }
    public List<Wishlist>? Wishlists { get; set; }
    public List<Favorite>? Favorites { get; set; }
    public List<Blog>? Blogs { get; set; }
}