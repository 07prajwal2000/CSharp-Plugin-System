using PluginDemo.Core;

namespace PluginDemo.Http;

public class LoadPluginMetadata : ILoadMetadata
{
    public PluginMetadata LoadMetadata()
    {
        return new PluginMetadata
        {
            Name = "Http Client",
            Description = "This is a Http client plugin, helps to call http endpoints.",
            Version = "1.0",
            Url = "https://google.com"
        };
    }
}