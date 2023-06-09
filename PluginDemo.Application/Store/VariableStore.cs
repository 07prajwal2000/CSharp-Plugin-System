using PluginDemo.Core.ValueTypes;

namespace PluginDemo.Core.Store;

public class VariableStore : IVariableStore
{
    private readonly PluginVariableStore _variableStore;

    public VariableStore(PluginVariableStore variableStore)
    {
        _variableStore = variableStore;
    }

    public bool HasVariable(string name) => _variableStore.HasVariable(name);
    
    public AbstractValueType GetVariable(string name)
    {
        return _variableStore.GetVariable(name);
    }
}