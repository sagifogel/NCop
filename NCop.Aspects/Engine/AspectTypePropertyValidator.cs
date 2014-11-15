using System;
using System.Linq;
using System.Reflection;
using NCop.Aspects.Aspects;
using NCop.Aspects.Exceptions;
using NCop.Aspects.Extensions;
using NCop.Aspects.Framework;
using NCop.Aspects.Properties;
using NCop.Core.Extensions;

namespace NCop.Aspects.Engine
{
    public static class AspectTypePropertyValidator
    {
        public static void ValidatePropertyAspect(IAspect aspect, PropertyInfo propertyInfo) {
            MethodInfo method = null;
            Type argumentsType = null;
            Type[] genericArguments = null;
            Type[] comparedTypes = Type.EmptyTypes;
            ParameterInfo[] aspectParameters = null;
            var overridenMethods = aspect.AspectType.GetOverridenMethods();

            if (aspect.Is<PropertyInterceptionAspectAttribute>() && !typeof(IPropertyInterceptionAspect).IsAssignableFrom(aspect.AspectType)) {
                var argumentException = new ArgumentException(Resources.PropertyInterceptionAspectAttributeErrorInitialization, "aspectType");

                throw new AspectAnnotationException(argumentException);
            }

            if (overridenMethods.Length == 0) {
                throw new AdviceNotFoundException(aspect.GetType());
            }

            method = overridenMethods[0];
            aspectParameters = method.GetParameters();

            if (aspectParameters.Length != 1) {
                throw new AspectTypeMismatchException(Resources.AspectPropertyParameterMismatach.Fmt(propertyInfo.Name));
            }

            argumentsType = aspectParameters[0].ParameterType;
            genericArguments = argumentsType.GetGenericArguments();

            if (!ValidatePropertyType(propertyInfo.PropertyType, genericArguments)) {
                throw new AspectTypeMismatchException(Resources.AspectPropertyParameterMismatach.Fmt(propertyInfo.Name));
            }
        }

        private static bool ValidatePropertyType(Type propertyType, Type[] comparedTypes) {
            return propertyType.Equals(comparedTypes[0]);
        }
    }
}
