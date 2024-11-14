namespace BookWave.Repository.Settings;
public class ConnectionStringSetting
{
    public const string Key = "ConnectionStrings";
    public string SqlServer { get; set; } = default!;
}
