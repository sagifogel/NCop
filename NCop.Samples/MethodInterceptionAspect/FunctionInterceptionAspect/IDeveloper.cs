using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.MethodInterceptionAspect.FunctionInterceptionAspect
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        [MethodInterceptionAspect(typeof(StopwatchInterceptionAspect))]
        string Code(string code);
    }
}
