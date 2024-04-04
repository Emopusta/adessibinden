namespace Core.Logging.Configurations;

public class GrafanaLokiConfiguration
{
    public bool Enabled { get; set; }
    public string MinimumLevel { get; set; }
    public string URL { get; set; }
    public Dictionary<string,string> Labels { get; set; }

}
