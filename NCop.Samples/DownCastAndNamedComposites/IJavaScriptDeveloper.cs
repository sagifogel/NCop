using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.DownCastAndNamedComposites
{
    [Named("JavaScript")]
    [Mixins(typeof(JavaScriptDeveloperMixin))]
    [TransientComposite(As = typeof(IDeveloper))]
    public interface IJavaScriptDeveloper : IDeveloper
    {
    }
}
