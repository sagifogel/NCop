using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.DownCastAndNamedComposites
{
    [Named("C#")]
    [Mixins(typeof(CSharpDeveloperMixin))]
    [TransientComposite(As = typeof(IDeveloper))]
    public interface ICSharpDeveloper : IDeveloper
    {
    }
}
