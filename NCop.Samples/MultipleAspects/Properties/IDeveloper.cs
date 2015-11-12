using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.MultipleAspects.Properties
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        [PropertyInterceptionAspect(typeof(PropertyInterceptionAspect), AspectPriority = 1)]
        [PropertyInterceptionAspect(typeof(AnotherPropertyInterceptionAspect), AspectPriority = 2)]
        string Code { get; set; }
    }
}
