using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.MultipleAspects.Methods.AspectsPriority
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        [MethodInterceptionAspect(typeof(InterceptionAspectImpl), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(OnMethodBoundaryAspectImpl), AspectPriority = 2)]
        void Code();
    }
}
