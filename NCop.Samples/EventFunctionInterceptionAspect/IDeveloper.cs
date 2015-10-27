using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;

namespace NCop.Samples.EventFunctionInterceptionAspect
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        [EventInterceptionAspect(typeof(SimpleEventInterceptionAspect))]
        event Func<string> OnCodeCompleted;

        string Code();
    }
}
