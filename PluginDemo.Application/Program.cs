using PluginDemo.Core;

var loader = new PluginLoader(@"C:\Personal\Programming-Files\PluginDemo.App\plugins");
Console.WriteLine("Loading plugins...");
loader.Load();
Console.WriteLine("Total Plugins count- " + loader.PluginsCount);
foreach (var metadata in loader.GetPluginsMetadataList())
{
    Console.WriteLine(metadata.Name);
}

var plugin = loader.GetPlugin("Http Client");
var variable = plugin.PluginVariableStore.GetVariable("URL");
variable.SetValue(@"https://prajwalaradhya.live/");
plugin.Execute("Http Helper");