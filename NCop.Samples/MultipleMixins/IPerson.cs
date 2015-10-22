using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.MultipleMixins
{
    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin), typeof(GuitarPlayerMixin))]
    public interface IPerson : IDeveloper, IMusician
    {
    }
}
