using NCop.Composite.Framework;
using NCop.Mixins.Framework;

namespace NCop.Samples.Generics.GenericComposites
{
    [TransientComposite]
    [Mixins(typeof(GenericCSharpDeveloperMixin))]
    public interface ICSharpDeveloper : IDeveloper<CSharpLanguage>
    {
    }
}
