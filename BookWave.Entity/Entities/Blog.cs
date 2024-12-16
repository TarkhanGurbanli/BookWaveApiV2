using BookWave.Entity.Base;

namespace BookWave.Entity.Entities;
public class Blog : BaseEntity
{
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public int UserId { get; set; } 
    public User User { get; set; } = default!;
    public List<Comment>? Comments { get; set; }
}