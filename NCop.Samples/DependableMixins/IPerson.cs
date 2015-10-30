using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.DependableMixins
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin), typeof(GuitarPlayerMixin))]
    public interface IPerson : IDeveloper, IMusician
    {
    }
}
