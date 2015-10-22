using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using NCop.Aspects.Framework;

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
