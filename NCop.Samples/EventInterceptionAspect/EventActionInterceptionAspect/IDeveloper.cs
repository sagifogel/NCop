using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;

namespace NCop.Samples.EventInterceptionAspect.EventActionInterceptionAspect
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
