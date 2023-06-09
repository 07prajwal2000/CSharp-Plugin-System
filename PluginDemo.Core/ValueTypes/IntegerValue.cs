namespace PluginDemo.Core.ValueTypes;

public class IntegerValue : AbstractValueType
{
    public IntegerValue(int value)
    {
        this.value = value;
    }
    
    public float GetValue() => (float)value;
    
    public override ValueTypeEnum GetValueType()
    {
        return ValueTypeEnum.Integer;
    }
    
    public override void SetValue(object value)
    {
        this.value = value;
    }
}