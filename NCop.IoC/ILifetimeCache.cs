
using System;

namespace NCop.IoC
{
    public interface ILifetimeCache
    {
        void Dispose();
        bool Remove(Type serviceType);
        bool Contains(Type serviceType);
        TService GetOrAdd<TService>(Func<TService> factory);
    }
}
