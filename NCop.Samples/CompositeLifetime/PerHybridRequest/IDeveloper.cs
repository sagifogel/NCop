using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.CompositeLifetime.PerHybridRequest
{
    [PerHybridRequestComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        void Code();
    }
}
