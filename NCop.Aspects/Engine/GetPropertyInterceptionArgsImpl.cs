using System.Reflection;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Engine
{
    public class GetPropertyInterceptionArgsImpl<TInstance, TArg> : AbstractPropertyInterceptionArgs<TInstance, TArg>
    {
        public GetPropertyInterceptionArgsImpl(TInstance instance, MethodInfo method, IPropertyBinding<TInstance, TArg> propertyBinding)
            : base(instance, method, propertyBinding) {
        }
    }
}
