using NCop.Composite.Framework;
using NCop.IoC.Fluent;
using System;
using System.Reflection;
using NCop.Core.Extensions;

namespace NCop.Composite.IoC
{
    public class CompositeFrameworkRegistration : ReflectionRegistration
    {
        private Type actualServiceType = null;

        public CompositeFrameworkRegistration(Type concreteType, Type serviceType, Type castAs = null)
            : base(concreteType, castAs ?? serviceType) {
            NamedAttribute namedAttribute = null;

            actualServiceType = serviceType;

            if (IsSingletonComposite()) {
                AsSingleton();
            }

            if (TryGetNamedAttribute(out namedAttribute)) {
                Named(namedAttribute.Name);
            }
        }

        private bool IsSingletonComposite() {
            return concreteType.IsDefined<SingletonCompositeAttribute>() ||
                   ServiceType.IsDefined<SingletonCompositeAttribute>();
        }

        private bool TryGetNamedAttribute(out NamedAttribute namedAttribute) {
            namedAttribute = concreteType.GetCustomAttribute<NamedAttribute>() ??
                             actualServiceType.GetCustomAttribute<NamedAttribute>();

            return namedAttribute.IsNotNull();
        }
    }
}
