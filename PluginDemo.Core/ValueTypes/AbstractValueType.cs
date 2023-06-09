namespace PluginDemo.Core.ValueTypes;

public abstract class AbstractValueType
{
    public string Name { get; set; }
    public string Description { get; set; }
    public object value { get; internal set; }
    
    public abstract ValueTypeEnum GetValueType();
    public abstract void SetValue(object value);
    public T Get<T>() => (T)value;
}