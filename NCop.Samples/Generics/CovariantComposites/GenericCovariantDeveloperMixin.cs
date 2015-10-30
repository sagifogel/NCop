
namespace NCop.Samples.Generics.CovariantComposites
{
    public class GenericCovariantDeveloperMixin<T> : ICovariantDeveloper<T> where T : CILLanguage, new()
    {
        private readonly T langugae = new T();

        public string Code() {
            return langugae.Name;
        }
    }
}
