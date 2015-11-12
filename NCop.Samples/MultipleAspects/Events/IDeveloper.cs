using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;

namespace NCop.Samples.MultipleAspects.Events
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        [EventInterceptionAspect(typeof(EventInterceptionAspect), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(AnotherEventInterceptionAspect), AspectPriority = 2)]
        event Action<string> OnCodeCompleted;

        void Code(string code);
    }
}
