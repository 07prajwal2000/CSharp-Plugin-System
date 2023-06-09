using System.Reflection;
using PluginDemo.Core.Store;
using PluginDemo.Core.ValueTypes;

namespace PluginDemo.Core;

public class Plugin
{
    private Dictionary<string, Executable> _executables = new();
    
    public Plugin()
    {
        
    }
    
    public Assembly PluginAssembly { get; init; } = null!;
    public PluginMetadata PluginMetadata { get; init; } = null!;
    public List<AbstractValueType> GlobalRequirements { get; init; } = null!;
    public List<IExecute> Executables { get; init; }
    public IVariableStore VariableStore { get; set; } = null!;
    public PluginVariableStore PluginVariableStore { get; set; } = null!;

    public void SetVariable(AbstractValueType value)
    {
        PluginVariableStore.SetVariable(value);
    }

    public void Initialize()
    {
        foreach (var executable in Executables)
        {
            var metadata = executable.LoadMetadata();
            var functionalRequirements = executable.LoadFunctionalRequirements();
            var exec = new Executable
            {
                Metadata = metadata,
                Requirements = functionalRequirements,
                Task = executable
            };
            _executables.Add(metadata._name, exec);
        }
    }
    
    public void Execute(string name)
    {
        if (!_executables.ContainsKey(name))
        {
            return;
        }
        _executables[name].Task.Execute(VariableStore);
    }
}