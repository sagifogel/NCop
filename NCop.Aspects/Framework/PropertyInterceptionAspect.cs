
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public abstract class PropertyInterceptionAspect<TArg> : IPropertyInterceptionAspect<TArg>, IPropertyInterceptionAspect
	{
        [OnGetPropertyInvokeAdviceAttribute]
        public virtual void OnGetValue(PropertyInterceptionArgs<TArg> args) {
            args.ProceedGetValue();
        }

        [OnSetPropertyInvokeAdviceAttribute]
        public virtual void OnSetValue(PropertyInterceptionArgs<TArg> args) {
            args.ProceedSetValue();
        }
	}
}
