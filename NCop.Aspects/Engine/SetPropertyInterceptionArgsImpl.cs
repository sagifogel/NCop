using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class SetPropertyInterceptionArgsImpl<TInstance, TArg> : AbstractPropertyInterceptionArgs<TInstance, TArg>
    {
        public SetPropertyInterceptionArgsImpl(TInstance instance, MethodInfo method, IPropertyBinding<TInstance, TArg> propertyBinding, TArg value)
            : base(instance, method, propertyBinding) {
            Value = value;
        }
    }
}
