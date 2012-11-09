using NCop.Aspects.Aspects;
using NCop.Aspects.Aspects.Interception;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Framework
{
    public abstract class OnMethodBoundryConcernOf<TInstance> : OnMethodBoundryConcern where TInstance : class
    {
        public OnMethodBoundryConcernOf(TInstance instance) {
            Instance = instance;
        }
        
        public TInstance Instance { get; private set; }
    }
}
