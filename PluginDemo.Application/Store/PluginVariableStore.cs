using PluginDemo.Core.ValueTypes;

namespace PluginDemo.Core.Store;

public class PluginVariableStore
{
    private readonly Plugin _plugin;
    private Dictionary<string, AbstractValueType> _variableStores = new();

    public PluginVariableStore(Plugin plugin)
    {
        _plugin = plugin;
    }

    public void SetVariable(AbstractValueType valueType)
    {
        if (_variableStores.ContainsKey(valueType.Name))
        {
            _variableStores[valueType.Name] = valueType;
            return;
        }
        _variableStores.Add(valueType.Name, valueType);
    }

    public bool HasVariable(string name) => _variableStores.ContainsKey(name);

    public AbstractValueType GetVariable(string name)
    {
        return _variableStores[name];
    }
}