using NCop.Core.Extensions;
using NCop.IoC.Framework;
using NCop.IoC.Properties;
using System;
using System.Reflection;

namespace NCop.IoC.Extensions
{
    public static class RegistrationExtensions
    {
        public static ConstructorInfo GetSingleConstructorOrAnnotated(this Type type) {
            var ctors = type.GetConstructors();

            if (ctors.Length > 1) {
                var dependentCtors = ctors.ToArray(ctor => ctor.IsDefined<DependencyAttribute>());

                if (dependentCtors.Length != 1) {
                    throw new RegistrationException(Resources.AmbigiousConstructorDependency.Fmt(type));
                }

                ctors = dependentCtors;
            }

            return ctors[0];
        }
    }
}
