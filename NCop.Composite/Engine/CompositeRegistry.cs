using NCop.Composite.Framework;
using NCop.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;
using NCop.IoC.Fluent;
using System.Reflection;
using NCop.Composite.IoC;
using NCop.Core;

namespace NCop.Composite.Engine
{
    internal class CompositeRegistry : ContainerRegistry
    {
        public override void Register(Type concreteType, Type serviceType, ITypeMap dependencies, string name = null) {
            CompositeFrameworkRegistration compositeRegistration = null;

            if (IsNotIgnoreRegistration(concreteType, serviceType)) {
                Type castAs = null;
                CompositeAttribute compositeAttr = null;

                if (TryGetCompositeAttribute(concreteType, serviceType, out compositeAttr)) {
                    castAs = compositeAttr.As;
                }

                compositeRegistration = new CompositeFrameworkRegistration(this, concreteType, serviceType, dependencies, castAs);
                registrations.Add(concreteType, compositeRegistration);
            }
        }

        private bool IsNotIgnoreRegistration(Type concreteType, Type serviceType) {
            return !(concreteType.IsDefined<IgnoreRegistration>() ||
                     serviceType.IsDefined<IgnoreRegistration>());
        }

        private bool TryGetCompositeAttribute(Type concreteType, Type serviceType, out CompositeAttribute compositeAttribute) {
            compositeAttribute = concreteType.GetCustomAttribute<CompositeAttribute>() ??
                                 serviceType.GetCustomAttribute<CompositeAttribute>();

            return compositeAttribute.IsNotNull();
        }
    }
}
