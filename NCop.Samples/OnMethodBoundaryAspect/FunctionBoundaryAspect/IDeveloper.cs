using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.OnMethodBoundaryAspect.FunctionBoundaryAspect
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        [OnMethodBoundaryAspect(typeof(StopwatchMethodBoundaryAspect))]
        string Code();
    }
}
