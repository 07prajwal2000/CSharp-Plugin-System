using PluginDemo.Core;
using PluginDemo.Core.ValueTypes;

namespace PluginDemo.FileLoader;

public class InitializeGlobalRequirements : IGlobalRequirements
{
    public List<AbstractValueType> LoadGlobalRequirementsDefinition()
    {
        return Enumerable.Empty<AbstractValueType>().ToList();
    }
}