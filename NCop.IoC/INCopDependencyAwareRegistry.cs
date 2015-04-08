using NCop.Core;
using System;

namespace NCop.IoC
{
    public interface INCopDependencyAwareRegistry
    {
        void Register(Type concreteType, Type serviceType, ITypeMap dependencies = null, string name = null, bool isComposite = false);
    }
}
