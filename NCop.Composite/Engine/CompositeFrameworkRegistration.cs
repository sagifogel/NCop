using NCop.Composite.Framework;
using NCop.IoC.Fluent;
using System;
using NCop.Core.Extensions;

namespace NCop.Composite.Engine
{
    public class CompositeFrameworkRegistration : ReflectionRegistration
    {
        public CompositeFrameworkRegistration(Type concreteType, Type serviceType)
            : base(concreteType, serviceType) {
            NamedAttribute namedAttribute = null;

            if (concreteType.IsDefined<SingletonAttribute>() || serviceType.IsDefined<SingletonAttribute>()) {
                AsSingleton();
            }

            namedAttribute = concreteType.GetCustomAttribute<NamedAttribute>() ?? serviceType.GetCustomAttribute<NamedAttribute>();

            if (namedAttribute.IsNotNull() && namedAttribute.Name.IsNotNullOrEmpty()) {
                Named(namedAttribute.Name);
            }
        }
    }
}
