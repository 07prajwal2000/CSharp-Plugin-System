namespace PluginDemo.Core;

public interface IExecute : IFunctionalRequirements, IFunctionalMetadata
{
    void Execute(IVariableStore variableStore);
}