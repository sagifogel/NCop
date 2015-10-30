using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.CompositeLifetime.Transient
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        void Code();
    }
}
