using PluginDemo.Core;

namespace PluginDemo.FileLoader;

public class LoadFileLoaderMetadata : ILoadMetadata
{
    public PluginMetadata LoadMetadata()
    {
        return new PluginMetadata
        {
            Name = "File loader",
            Description = "This is a file loader",
            Url = "https://google.com",
            Version = "0.1"
        };
    }
}