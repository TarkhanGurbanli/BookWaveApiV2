using BookWave.Entity.Base;
using BookWave.Entity.Enums;

namespace BookWave.Entity.Entities;
public class PhotoFile : BaseEntity
{
    public string Base64Content { get; init; } = string.Empty; 
    public string FileName { get; init; } = string.Empty;
    public string? ContentType { get; init; }
    public ImageType ImageType { get; set; }

}