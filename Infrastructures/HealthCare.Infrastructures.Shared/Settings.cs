namespace HealthCare.Infrastructures.Shared;

public class Settings
{
    public string AppName { get; set; }
    public string AppVersion { get; set; }

    public RedisSetting RedisSetting { get; set; }
    public string DocumentsLocation { get; set; }
}

public class RedisSetting
{
    public bool IsActive { get; set; }
    public string RedisServer { get; set; }
    public int PortNumber { get; set; }
    public int RedisDatabaseNumber { get; set; }
}