using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.DownCast
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        void Code();
    }
}
