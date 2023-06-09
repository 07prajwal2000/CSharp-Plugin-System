using PluginDemo.Core.ValueTypes;

namespace PluginDemo.Core;

public interface IVariableStore
{
    AbstractValueType GetVariable(string name);
    bool HasVariable(string name);
}