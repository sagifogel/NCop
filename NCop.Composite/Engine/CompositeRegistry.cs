using NCop.Composite.Framework;
using NCop.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;
using NCop.IoC.Fluent;

namespace NCop.Composite.Engine
{
    internal class CompositeRegistry : ContainerRegistry
    {
        public override IRegistration Register(Type concreteType, Type serviceType) {
            CompositeFrameworkRegistration compositeRegistration = null;

            if (!(concreteType.IsDefined<IgnoreRegistration>() || serviceType.IsDefined<IgnoreRegistration>())) {
                compositeRegistration = new CompositeFrameworkRegistration(concreteType, serviceType);
                registrations.Add(compositeRegistration);
            }

            return compositeRegistration;
        }
    }
}
