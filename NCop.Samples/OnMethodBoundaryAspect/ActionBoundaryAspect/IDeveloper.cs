using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.OnMethodBoundaryAspect.ActionBoundaryAspect
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        [OnMethodBoundaryAspect(typeof(StopwatchMethodBoundaryAspect))]
        void Code();
    }
}
