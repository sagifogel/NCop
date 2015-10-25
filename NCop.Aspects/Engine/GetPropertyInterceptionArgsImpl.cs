using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class GetPropertyInterceptionArgsImpl<TInstance, TArg> : AbstractPropertyInterceptionArgs<TInstance, TArg>
    {
        public GetPropertyInterceptionArgsImpl(TInstance instance, PropertyInfo property, IPropertyBinding<TInstance, TArg> propertyBinding)
            : base(instance, property, propertyBinding) {
        }
    }
}
