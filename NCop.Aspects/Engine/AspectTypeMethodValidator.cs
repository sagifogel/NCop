using NCop.Aspects.Aspects;
using NCop.Aspects.Exceptions;
using NCop.Aspects.Extensions;
using NCop.Aspects.Framework;
using NCop.Aspects.Properties;
using NCop.Core.Extensions;
using System;
using System.Linq;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public static class AspectTypeMethodValidator
    {
        public static void ValidateMethodAspect(IAspect aspect, MethodInfo method) {
            Type argumentsType = null;
            Type[] genericArguments = null;
            var comparedTypes = Type.EmptyTypes;
            ParameterInfo[] methodParameters = null;
            ParameterInfo[] aspectParameters = null;
            var overridenMethods = aspect.AspectType.GetOverridenMethods();

            if (overridenMethods.Length == 0) {
                throw new AdviceNotFoundException(aspect.GetType());
            }

            if (aspect.Is<OnMethodBoundaryAspectAttribute>() && !typeof(IOnMethodBoundaryAspect).IsAssignableFrom(aspect.AspectType)) {
                var argumentException = new ArgumentException(Resources.OnMethodBoundaryAspectAttributeErrorInitialization, "aspectType");

                throw new AspectAnnotationException(argumentException);
            }

            if (aspect.Is<MethodInterceptionAspectAttribute>() && !typeof(IMethodInterceptionAspect).IsAssignableFrom(aspect.AspectType)) {
                var argumentException = new ArgumentException(Resources.MethodInterceptionAspectAttributeErrorInitialization, "aspectType");

                throw new AspectAnnotationException(argumentException);
            }

            aspectParameters = overridenMethods[0].GetParameters();

            if (aspectParameters.Length == 0) {
                throw new AspectTypeMismatchException(Resources.AspectMethodParametersMismatach.Fmt(method.Name));
            }

            methodParameters = method.GetParameters();
            argumentsType = aspectParameters[0].ParameterType;
            genericArguments = argumentsType.GetGenericArguments();

            if (method.HasReturnType()) {
                var argumentsLength = 0;
                Type aspectReturnType = null;

                if (typeof(IActionExecutionArgs).IsAssignableFrom(argumentsType)) {
                    throw new AspectAnnotationException(Resources.FunctionAspectMismatch);
                }

                if (genericArguments.Length == 0) {
                    throw new AspectTypeMismatchException(Resources.AspectReturnTypeMismatch.Fmt(method.Name));
                }

                argumentsLength = genericArguments.Length - 1;
                aspectReturnType = genericArguments[argumentsLength];

                if (genericArguments.Length > 1) {
                    comparedTypes = genericArguments.Take(argumentsLength)
                                                    .ToArray();
                }

                if (!ValidateReturnType(method.ReturnType, aspectReturnType)) {
                    throw new AspectTypeMismatchException(Resources.AspectReturnTypeMismatch.Fmt(method.Name));
                }
            }
            else {
                comparedTypes = genericArguments;

                if (!typeof(IPropertyInterceptionArgs).IsAssignableFrom(argumentsType) && (typeof(IFunctionExecutionArgs).IsAssignableFrom(argumentsType) || typeof(IFunctionInterceptionArgs).IsAssignableFrom(argumentsType))) {
                    throw new AspectAnnotationException(Resources.FunctionAspectMismatch);
                }
            }

            if (!ValidateParameters(methodParameters, comparedTypes)) {
                throw new AspectTypeMismatchException(Resources.AspectMethodParametersMismatach.Fmt(method.Name));
            }
        }

        private static bool ValidateParameters(ParameterInfo[] methodParameters, Type[] comparedTypes) {
            return methodParameters.Length == comparedTypes.Length &&
                   methodParameters.All((p, i) => {
                       var parameterType = p.ParameterType;

                       if (parameterType.IsByRef) {
                           parameterType = parameterType.GetElementType();
                       }

                       return ReferenceEquals(parameterType, comparedTypes[i]);
                   });
        }

        private static bool ValidateReturnType(Type methodReturnType, Type aspectReturnType) {
            return ReferenceEquals(methodReturnType, aspectReturnType);
        }
    }
}
