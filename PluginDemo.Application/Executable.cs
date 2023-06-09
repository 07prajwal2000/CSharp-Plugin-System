using PluginDemo.Core.ValueTypes;

namespace PluginDemo.Core;

public class Executable
{
    public IExecute Task { get; set; }
    public FunctionalMetadata Metadata { get; set; }
    public IReadOnlyList<AbstractValueType> Requirements { get; set; }
}