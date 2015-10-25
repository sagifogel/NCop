using NCop.Mixins.Framework;
using NCop.Composite.Framework;
using NCop.Aspects.Framework;
using System;

namespace NCop.Samples.EventActionInterceptionAspect
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        [EventInterceptionAspect(typeof(SimpleEventInterceptionAspect))]
        event Action<string> OnCodeCompleted;

        void Code(string code);
    }
}
