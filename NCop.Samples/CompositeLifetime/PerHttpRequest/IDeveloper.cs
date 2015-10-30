using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.CompositeLifetime.PerHttpRequest
{
    [PerHttpRequestComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        void Code();
    }
}
