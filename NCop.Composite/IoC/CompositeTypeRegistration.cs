
using System;
using System.Collections.Generic;
using NCop.Core;
using NCop.IoC;

namespace NCop.Composite.IoC
{
    internal class CompositeTypeRegistration : CompositeFrameworkRegistration
    {
        internal CompositeTypeRegistration(IRegistrationResolver registrationResolver, Type concreteType, Type serviceType, IEnumerable<TypeMap> dependencies, Type castTo, string name, bool disposable)
            : base(registrationResolver, concreteType, serviceType, dependencies, castTo, name, disposable) {
        }
    }
}
