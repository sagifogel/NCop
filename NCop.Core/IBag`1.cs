
namespace NCop.Core
{
    public interface IBag<in T>
    {
        void Add(T item);
    }
}
