using PluginDemo.Core;
using PluginDemo.Core.ValueTypes;

namespace PluginDemo.Http;

public class HttpHelper : IExecute
{
    public void Execute(IVariableStore variableStore)
    {
        var url = variableStore.GetVariable("URL").Get<string>();
        using var http = new HttpClient();
        var result = http.GetAsync(url).GetAwaiter().GetResult();
        Console.WriteLine("Status code- " + result.StatusCode);
    }

    public FunctionalMetadata LoadMetadata()
    {
        return new FunctionalMetadata("Http Helper", "A Http client helps to get data from the internet");
    }

    public List<AbstractValueType> LoadFunctionalRequirements()
    {
        return new List<AbstractValueType>
        {
            new StringValue("")
            {
                Name = "URL",
                Description = "URL of the server"
            }
        };
    }
}