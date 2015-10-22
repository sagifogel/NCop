using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using NCop.Aspects.Framework;

namespace NCop.Samples.MethodInterceptionAspect.ActionInterceptionAspect
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        [MethodInterceptionAspect(typeof(StopwatchInterceptionAspect))]
        void Code(string code);
    }
}
