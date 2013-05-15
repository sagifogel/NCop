using NCop.IoC.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public interface IRegistry
    {
        bool Contains(Type serviceType);
        void Register(Type concreteType, Type serviceType);
    }
}
