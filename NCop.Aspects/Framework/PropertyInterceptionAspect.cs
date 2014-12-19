
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public abstract class PropertyInterceptionAspect<TArg> : IPropertyInterceptionAspect<TArg>, IPropertyInterceptionAspect
	{
        [OnGetPropertyAdviceAttribute]
        public virtual void OnGetValue(PropertyInterceptionArgs<TArg> args) {
            args.ProceedGetValue();
        }

        [OnSetPropertyAdviceAttribute]
        public virtual void OnSetValue(PropertyInterceptionArgs<TArg> args) {
            args.ProceedSetValue();
        }
	}
}
