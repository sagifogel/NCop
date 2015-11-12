using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.MultipleAspects.Methods.SameAspectType
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        [MethodInterceptionAspect(typeof(AnotherInterceptionAspectImpl))]
        [MethodInterceptionAspect(typeof(InterceptionAspectImpl))]
        void Code();
    }
}
