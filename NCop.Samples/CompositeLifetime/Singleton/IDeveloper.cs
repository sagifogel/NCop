using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.CompositeLifetime.Singleton
{
    [SingletonComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        void Code();
    }
}
