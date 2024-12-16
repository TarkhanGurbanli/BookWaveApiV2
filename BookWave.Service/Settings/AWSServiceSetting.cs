namespace BookWave.Service.Settings;
public class AWSServiceSetting
{
    public string AccessKey { get; set; } = null!;
    public string SecretKey { get; set; } = null!;
    public string BucketName { get; set; } = null!;
    public string Region { get; set; } = null!;
}
