namespace PluginDemo.Core.ValueTypes;

public class StringValue : AbstractValueType
{
    public StringValue(string defaultValue)
    {
        this.value = defaultValue;
    }
    
    public string GetValue() => (string)value;
    
    public override ValueTypeEnum GetValueType()
    {
        return ValueTypeEnum.String;
    }
    
    public override void SetValue(object value)
    {
        this.value = value;
    }
}