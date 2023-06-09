using PluginDemo.Core;
using PluginDemo.Core.ValueTypes;

namespace PluginDemo.FileLoader;

public class FileLoader : IExecute
{
    public void Execute(IVariableStore variableStore)
    {
        var value = variableStore.GetVariable("File path");
        var text = File.ReadAllText(value.Get<string>());
        Console.WriteLine("File loaded- " + text);
    }

    public FunctionalMetadata LoadMetadata()
    {
        return new FunctionalMetadata("File loader", "Loads a file from disk");
    }

    public List<AbstractValueType> LoadFunctionalRequirements()
    {
        return new List<AbstractValueType>
        {
            new StringValue("")
            {
                Name = "File path",
                Description = "The path of the file to load from disk"
            }
        };
    }
}