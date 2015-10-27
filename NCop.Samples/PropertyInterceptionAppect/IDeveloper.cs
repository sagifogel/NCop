using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;

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
