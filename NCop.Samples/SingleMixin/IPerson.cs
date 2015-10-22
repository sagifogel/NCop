using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.SingleMixin
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IPerson : IDeveloper
    {
    }
}
