using System;

namespace NCop.IoC
{
    public interface INCopRegistry
    {
        void Register(Type concreteType, Type serviceType, string name = null);
    }
}
