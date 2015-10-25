using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class SetPropertyInterceptionArgsImpl<TInstance, TArg> : AbstractPropertyInterceptionArgs<TInstance, TArg>
    {
        public SetPropertyInterceptionArgsImpl(TInstance instance, PropertyInfo property, IPropertyBinding<TInstance, TArg> propertyBinding, TArg value)
            : base(instance, property, propertyBinding) {
            Value = value;
        }
    }
}
