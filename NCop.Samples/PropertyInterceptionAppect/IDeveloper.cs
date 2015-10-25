using NCop.Mixins.Framework;
using NCop.Composite.Framework;
using NCop.Aspects.Framework;

namespace NCop.Samples.PropertyInterceptionAppect
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        [PropertyInterceptionAspect(typeof(SimplePropertyInterceptionAspect))]
        string Code { get; set; }
    }
}
