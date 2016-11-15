using System.Reflection;
using Omu.ValueInjecter.Injections;

namespace Test.ValueInjecter.Tests.Mics
{
    public class IntToStringFlat : FlatLoopInjection
    {
        protected override bool Match(string propName, PropertyInfo unflatProp, PropertyInfo targetFlatProp)
        {
            return propName == unflatProp.Name && unflatProp.PropertyType == typeof(int) && targetFlatProp.PropertyType == typeof(string);
        }

        protected override void SetValue(object source, object target, PropertyInfo sp, PropertyInfo tp)
        {
            var val = sp.GetValue(source).ToString();
            tp.SetValue(target, val);
        }
    }
}