using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NCop.Core.Extensions;
using System.Reflection;
using NCop.IoC.Framework;
using NCop.IoC.Properties;

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
