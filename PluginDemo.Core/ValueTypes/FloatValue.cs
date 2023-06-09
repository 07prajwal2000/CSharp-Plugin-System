namespace PluginDemo.Core.ValueTypes;

public class FloatValue : AbstractValueType
{
    public FloatValue(float value)
    {
        base.value = value;
    }
    public string GetValue() => (string)value;
    
    public override ValueTypeEnum GetValueType()
    {
        return ValueTypeEnum.Float;
    }

    public override void SetValue(object value)
    {
        this.value = value;
    }
}