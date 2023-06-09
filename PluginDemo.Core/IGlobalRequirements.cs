using PluginDemo.Core.ValueTypes;

namespace PluginDemo.Core;

public interface IGlobalRequirements
{
    List<AbstractValueType> LoadGlobalRequirementsDefinition();
}