
namespace NCop.Samples.Generics.CovariantComposites
{
    public interface ICovariantDeveloper<out T>
    {
        string Code();
    }
}
