using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCop.Aspects.Engine;
using NCop.Aspects.Exceptions;
using NCop.Aspects.Framework;
using NCop.Core.Exceptions;
using NCop.Core.Extensions;
using NCop.Aspects.Extensions;
using NCop.Aspects.Properties;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Engine
{
    public static class AspectTypeMethodValidator
    {
        public static void ValidateMethodAspect(IAspect aspect, MethodInfo methodInfo) {
            MethodInfo method = null;
            Type argumentsType = null;
            Type[] genericArguments = null;
            Type[] comparedTypes = Type.EmptyTypes;
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

            method = overridenMethods[0];
            aspectParameters = method.GetParameters();

            if (aspectParameters.Length == 0) {
                throw new AspectTypeMismatchException(Resources.AspectParametersMismatach.Fmt(methodInfo.Name));
            }

            methodParameters = methodInfo.GetParameters();
            argumentsType = aspectParameters[0].ParameterType;
            genericArguments = argumentsType.GetGenericArguments();

            if (methodInfo.HasReturnType()) {
                int argumentsLength = 0;
                Type aspectReturnType = null;

                if (typeof(IActionExecutionArgs).IsAssignableFrom(argumentsType)) {
                    throw new AspectAnnotationException(Resources.FunctionAspectMismatch);
                }

                if (genericArguments.Length == 0) {
                    throw new AspectTypeMismatchException(Resources.AspectReturnTypeMismatch.Fmt(methodInfo.Name));
                }

                argumentsLength = genericArguments.Length - 1;
                aspectReturnType = genericArguments[argumentsLength];

                if (genericArguments.Length > 1) {
                    comparedTypes = genericArguments.Take(argumentsLength)
                                                    .ToArray();
                }

                if (!ValidateReturnType(methodInfo.ReturnType, aspectReturnType)) {
                    throw new AspectTypeMismatchException(Resources.AspectReturnTypeMismatch.Fmt(methodInfo.Name));
                }
            }
            else {
                comparedTypes = genericArguments;

                if (typeof(IFunctionExecutionArgs).IsAssignableFrom(argumentsType)) {
                    throw new AspectAnnotationException(Resources.FunctionAspectMismatch);
                }
            }

            if (!ValidateParameters(methodParameters, comparedTypes)) {
                throw new AspectTypeMismatchException(Resources.AspectParametersMismatach.Fmt(methodInfo.Name));
            }
        }

        private static bool ValidateParameters(ParameterInfo[] methodParameters, Type[] comparedTypes) {
            return methodParameters.Length == comparedTypes.Length &&
                   methodParameters.All((p, i) => {
                       var parameterType = p.ParameterType;

                       if (parameterType.IsByRef) {
                           parameterType = parameterType.GetElementType();
                       }

                       return parameterType.Equals(comparedTypes[i]);
                   });
        }

        private static bool ValidateReturnType(Type methodReturnType, Type aspectReturnType) {
            return methodReturnType.Equals(aspectReturnType);
        }
    }
}
