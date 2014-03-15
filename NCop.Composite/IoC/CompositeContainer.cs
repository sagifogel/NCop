using NCop.IoC;
using NCop.IoC.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Composite.IoC
{
    internal class CompositeContainer : NCopContainer, IRegistrationResolver
    {
        public IRegistration Resolve(Type concreteType) {
            return registry.Resolve(concreteType);
        }
    }
}
