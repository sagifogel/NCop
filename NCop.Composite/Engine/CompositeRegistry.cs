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
            IFluentRegistration compositeRegistraion = null;

            if (!(concreteType.IsDefined<IgnoreRegistration>() || serviceType.IsDefined<IgnoreRegistration>())) {
                compositeRegistraion = new CompositeFrameworkRegistration(concreteType, serviceType);
                registrations.Add(compositeRegistraion);
            }

            return compositeRegistraion;
        }
    }
}
