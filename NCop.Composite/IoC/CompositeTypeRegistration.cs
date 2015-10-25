
using NCop.Core;
using NCop.IoC;
using System;
using System.Collections.Generic;

namespace NCop.Composite.IoC
{
    internal class CompositeTypeRegistration : CompositeFrameworkRegistration
    {
        internal CompositeTypeRegistration(IRegistrationResolver registrationResolver, TypeMap typeMap, IEnumerable<TypeMap> dependencies, Type castTo, bool disposable)
            : base(registrationResolver, typeMap, dependencies, castTo, disposable) {
        }
    }
}
