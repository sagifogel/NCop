

#if NET_4_0

namespace NCop.Core
{
    public interface IReadOnlyCollection<out T> : IEnumerable<T>
    {
        int Count { get; }
    }
}

#endif
