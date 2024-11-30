using BookWave.Entity.Base;
using BookWave.Entity.Enums;

namespace BookWave.Entity.Entities;
public class PhotoFile : BaseEntity
{
    public string ImageName { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public string Message { get; set; } = default!;
    public int Status { get; set; }
    public ImageType ImageType { get; set; }
}