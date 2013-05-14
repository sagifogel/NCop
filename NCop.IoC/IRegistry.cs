using NCop.IoC.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public interface IRegistry
    {
        void Register(Type concreteType, Type serviceType);
    }
}
