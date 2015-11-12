using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.MultipleAspects.Methods.DifferentAspectsType
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        [MethodInterceptionAspect(typeof(InterceptionAspectImpl))]
        [OnMethodBoundaryAspect(typeof(OnMethodBoundaryAspectImpl))]
        void Code();
    }
}
