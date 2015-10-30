using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.CompositeLifetime.PerThread
{
    [PerThreadComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        void Code();
    }
}
