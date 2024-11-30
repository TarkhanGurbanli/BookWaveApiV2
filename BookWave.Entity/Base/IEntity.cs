namespace BookWave.Entity.Base;

public interface IEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
