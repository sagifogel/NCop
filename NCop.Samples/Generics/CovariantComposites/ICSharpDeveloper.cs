using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.Generics.CovariantComposites
{
    [TransientComposite]
    [Mixins(typeof(GenericCovariantDeveloperMixin<CSharpLanguage>))]
    public interface ICSharpDeveloper : ICovariantDeveloper<CILLanguage>
    {
    }
}
