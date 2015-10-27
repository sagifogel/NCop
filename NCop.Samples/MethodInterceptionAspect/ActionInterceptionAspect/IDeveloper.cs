using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;

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
