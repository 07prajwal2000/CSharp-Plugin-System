using PluginDemo.Core;
using PluginDemo.Core.ValueTypes;

namespace PluginDemo.Http;

public class InitializeGlobalRequirements : IGlobalRequirements
{
    public List<AbstractValueType> LoadGlobalRequirementsDefinition()
    {
        return new List<AbstractValueType>
        {
            new IntegerValue(10)
            {
                Name = "Timeout",
                Description = "Http timeout value"
            }
        };
    }
}