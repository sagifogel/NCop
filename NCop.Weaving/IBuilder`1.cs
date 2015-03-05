
namespace NCop.Weaving
{
    public interface IBuilder<out T>
    {
        T Build();
    }
}
