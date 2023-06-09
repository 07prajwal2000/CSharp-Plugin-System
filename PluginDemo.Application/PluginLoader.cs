using System.Reflection;
using PluginDemo.Core.Store;

namespace PluginDemo.Core;

public class PluginLoader
{
    private readonly string _path;
    private readonly Dictionary<string, Plugin> _plugins = new();

    public PluginLoader(string path)
    {
        _path = path;
    }

    public void Load()
    {
        var dlls = Directory.GetFiles(_path, "*.dll", SearchOption.AllDirectories);
        
        foreach (var dll in dlls)
        {
            var assembly = Assembly.LoadFile(dll);
            
            var pluginType = assembly.ExportedTypes
                .Where(x => x is { IsAbstract: false, IsInterface: false })
                .ToArray();

            var metadata = LoadPluginMetadata(pluginType).LoadMetadata();
            var requirements = LoadRequirements(pluginType).LoadGlobalRequirementsDefinition();

            var executables = LoadInitializers(pluginType).ToList();
                
            var plugin = new Plugin
            {
                Executables = executables,
                GlobalRequirements = requirements,
                PluginAssembly = assembly,
                PluginMetadata = metadata
            };
            
            var pluginStore = new PluginVariableStore(plugin);
            
            foreach (var executable in executables)
            {
                var variables = executable.LoadFunctionalRequirements();
                foreach (var variable in variables)
                {
                    pluginStore.SetVariable(variable);
                }
            }
            
            plugin.VariableStore = new VariableStore(pluginStore);
            plugin.PluginVariableStore = pluginStore;
            _plugins.Add(metadata.Name, plugin);
            plugin.Initialize();
        }
    }

    public int PluginsCount => _plugins.Count;
    public IEnumerable<PluginMetadata> GetPluginsMetadataList()
    {
        return _plugins
            .Select(kvp => kvp.Value.PluginMetadata);
    }

    public Plugin GetPlugin(string name)
    {
        return _plugins[name];
    }

    private ILoadMetadata LoadPluginMetadata(Type[] plugin)
    {
        return plugin
            .Where(x => x.IsAssignableTo(typeof(ILoadMetadata)))
            .Select(Activator.CreateInstance)
            .Cast<ILoadMetadata>()
            .First();
    }
    
    private IGlobalRequirements LoadRequirements(Type[] plugin)
    {
        return plugin
            .Where(x => x.IsAssignableTo(typeof(IGlobalRequirements)))
            .Select(Activator.CreateInstance)
            .Cast<IGlobalRequirements>()
            .First();
    }

    private IEnumerable<IExecute> LoadInitializers(Type[] plugin)
    {
        return plugin
            .Where(x => x.IsAssignableTo(typeof(IExecute)))
            .Select(Activator.CreateInstance)
            .Cast<IExecute>();
    }
}