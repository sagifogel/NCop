using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class GetPropertyInterceptionArgsImpl<TInstance, TArg> : AbstractPropertyInterceptionArgs<TInstance, TArg>
    {
        public GetPropertyInterceptionArgsImpl(TInstance instance, MethodInfo method, IPropertyBinding<TInstance, TArg> propertyBinding)
            : base(instance, method, propertyBinding) {
        }
    }
}
