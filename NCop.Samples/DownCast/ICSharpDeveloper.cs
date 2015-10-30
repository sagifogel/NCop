using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.DownCast
{
    [Mixins(typeof(CSharpDeveloperMixin))]
    [TransientComposite(As = typeof(IDeveloper))]
    public interface ICSharpDeveloper : IDeveloper
    {
    }
}
