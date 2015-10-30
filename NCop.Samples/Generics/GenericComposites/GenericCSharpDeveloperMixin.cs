
namespace NCop.Samples.Generics.GenericComposites
{
    public class GenericCSharpDeveloperMixin : IDeveloper<CSharpLanguage>
    {
        public string Code() {
            return new CSharpLanguage().Name;
        }
    }
}
