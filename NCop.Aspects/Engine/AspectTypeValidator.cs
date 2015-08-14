using System.Diagnostics.Contracts;
using NCop.Aspects.Aspects;
using NCop.Aspects.Exceptions;
using NCop.Aspects.Extensions;
using NCop.Aspects.Framework;
using NCop.Aspects.Properties;
using NCop.Core.Exceptions;
using NCop.Core.Extensions;
using System;
using System.Linq;
using System.Reflection;
using CoreResources = NCop.Core.Properties.Resources;

namespace NCop.Aspects.Engine
{
    public static class AspectTypeValidator
    {
        public static void ValidateMethodAspect(IAspect aspect, AspectMap aspectMap) {
            ValidateMethodAspect(aspect, aspectMap.Method);
        }

        public static void ValidateMethodAspect(IAspect aspect, MethodInfo method) {
            var methodName = method.Name;
            var comparedTypes = Type.EmptyTypes;
            MethodInfo[] overridenMethods = null;
            var methodIsFunction = method.IsFunction();
            var methodParameters = method.GetParameters();

            if (aspect.Is<OnMethodBoundaryAspectAttribute>()) {
                if (!typeof(IOnMethodBoundaryAspect).IsAssignableFrom(aspect.AspectType)) {
                    var argumentException = new ArgumentException(Resources.OnMethodBoundaryAspectAttributeErrorInitialization, "aspectType");

                    throw new AspectAnnotationException(argumentException);
                }

                overridenMethods = aspect.AspectType.GetOverridenMethods()
                                                    .ToArray(overridenMethod => {
                                                        return overridenMethod.Name.Equals("OnExit") ||
                                                               overridenMethod.Name.Equals("OnEntry") ||
                                                               overridenMethod.Name.Equals("OnSuccess") ||
                                                               overridenMethod.Name.Equals("OnException");
                                                    });
            }
            else if (aspect.Is<MethodInterceptionAspectAttribute>()) {
                if (!typeof(IMethodInterceptionAspect).IsAssignableFrom(aspect.AspectType)) {
                    var argumentException = new ArgumentException(Resources.MethodInterceptionAspectAttributeErrorInitialization, "aspectType");

                    throw new AspectAnnotationException(argumentException);
                }

                overridenMethods = aspect.AspectType.GetOverridenMethods()
                                                    .ToArray(overridenMethod => overridenMethod.Name.Equals("OnInvoke"));
            }

            if (overridenMethods.Length == 0) {
                throw new AdviceNotFoundException(aspect.GetType());
            }

            overridenMethods.ForEach(overridenMethod => {
                Type argumentsType = null;
                Type[] genericArguments = null;
                var aspectParameters = overridenMethod.GetParameters();
                var aspectMethodIsFunction = overridenMethod.IsFunction();

                if (aspectParameters.Length != 1 || aspectMethodIsFunction) {
                    throw new AspectTypeMismatchException(Resources.AspectMethodParametersMismatach.Fmt(methodName));
                }

                argumentsType = aspectParameters[0].ParameterType;
                genericArguments = argumentsType.GetGenericArguments();

                if (methodIsFunction) {
                    var argumentsLength = 0;
                    Type aspectReturnType = null;

                    if (typeof(IActionExecutionArgs).IsAssignableFrom(argumentsType) || typeof(IActionInterceptionArgs).IsAssignableFrom(argumentsType)) {
                        throw new AspectAnnotationException(Resources.OnActionBoundaryAspcetMismatch);
                    }

                    if (genericArguments.Length == 0) {
                        throw new AspectTypeMismatchException(Resources.AspectReturnTypeMismatch.Fmt(methodName));
                    }

                    argumentsLength = genericArguments.Length - 1;
                    aspectReturnType = genericArguments[argumentsLength];

                    if (genericArguments.Length > 1) {
                        comparedTypes = genericArguments.Take(argumentsLength)
                                                        .ToArray();
                    }

                    if (!ValidateTypesAreEqual(method.ReturnType, aspectReturnType)) {
                        throw new AspectTypeMismatchException(Resources.AspectReturnTypeMismatch.Fmt(methodName));
                    }
                }
                else {
                    comparedTypes = genericArguments;

                    if (typeof(IFunctionExecutionArgs).IsAssignableFrom(argumentsType) || typeof(IFunctionInterceptionArgs).IsAssignableFrom(argumentsType)) {
                        throw new AspectAnnotationException(Resources.OnFunctionBoundaryAspcetMismatch);
                    }
                }

                if (!ValidateParameters(methodParameters, comparedTypes)) {
                    throw new AspectTypeMismatchException(Resources.AspectMethodParametersMismatach.Fmt(methodName));
                }
            });
        }

        public static void ValidatePropertyAspect(PropertyInfo target, IAspect aspect, AspectMap aspectMap) {
            ValidatePropertyAspect(aspect, (PropertyInfo)aspectMap.Contract, target);
        }

        public static void ValidatePropertyAspect(IAspect aspect, PropertyInfo contractProperty, PropertyInfo implementationProperty) {
            MethodInfo[] overridenMethods = null;
            var propertyName = contractProperty.Name;

            if (contractProperty.CanRead != implementationProperty.CanRead ||
                contractProperty.CanWrite != implementationProperty.CanWrite) {
                var contractDeclaringType = contractProperty.DeclaringType;
                var implementationDeclaringType = contractProperty.DeclaringType;

                throw new PropertyAccessorsMismatchException(CoreResources.PropertiesAccessorsMismatach.Fmt(propertyName, contractDeclaringType.FullName, implementationDeclaringType.FullName));
            }

            overridenMethods = aspect.AspectType.GetOverridenMethods().ToArray(method => method.Name.Equals("OnGetValue") || method.Name.Equals("OnSetValue"));

            if (overridenMethods.Length == 0) {
                throw new AdviceNotFoundException(aspect.GetType());
            }

            if (!typeof(IPropertyInterceptionAspect).IsAssignableFrom(aspect.AspectType)) {
                var argumentException = new ArgumentException(Resources.PropertyInterceptionAspectAttributeErrorInitialization, "aspectType");

                throw new AspectAnnotationException(argumentException);
            }

            overridenMethods.ForEach(overridenMethod => {
                Type argumentsType = null;
                Type[] genericArguments = null;
                var aspectParameters = overridenMethod.GetParameters();
                var aspectMethodIsFunction = overridenMethod.IsFunction();

                if (aspectParameters.Length != 1 || aspectMethodIsFunction) {
                    throw new AspectTypeMismatchException(Resources.AspectPropertyParameterMismatach.Fmt(propertyName));
                }

                argumentsType = aspectParameters[0].ParameterType;
                genericArguments = argumentsType.GetGenericArguments();

                if (!ValidateTypesAreEqual(contractProperty.PropertyType, genericArguments.FirstOrDefault())) {
                    throw new AspectTypeMismatchException(Resources.AspectPropertyParameterMismatach.Fmt(propertyName));
                }
            });
        }

        public static void ValidateEventAspect(IAspect aspect, AspectMap aspectMap) {
            ValidateEventAspect(aspect, (EventInfo)aspectMap.Target);
        }

        public static void ValidateEventAspect(IAspect aspect, EventInfo @event) {
            var comparedTypes = Type.EmptyTypes;
            var invokeMethod = @event.GetInvokeMethod();
            var methodIsFunction = invokeMethod.IsFunction();
            var methodParameters = invokeMethod.GetParameters();
            var overridenMethods = aspect.AspectType
                                         .GetOverridenMethods()
                                         .ToArray(overridenMethod => {
                                             return overridenMethod.Name.Equals("OnAddHandler") ||
                                                    overridenMethod.Name.Equals("OnInvokeHandler") ||
                                                    overridenMethod.Name.Equals("OnRemoveHandler");
                                         });

            if (!typeof(IEventInterceptionAspect).IsAssignableFrom(aspect.AspectType)) {
                var argumentException = new ArgumentException(Resources.EventInterceptionAspectAttributeErrorInitialization, "aspectType");

                throw new AspectAnnotationException(argumentException);
            }

            if (overridenMethods.Length == 0) {
                throw new AdviceNotFoundException(aspect.GetType());
            }

            overridenMethods.ForEach(overridenMethod => {
                Type argumentsType = null;
                var eventName = @event.Name;
                Type[] genericArguments = null;
                var aspectParameters = overridenMethod.GetParameters();
                var aspectMethodIsFunction = overridenMethod.IsFunction();

                if (aspectParameters.Length != 1 || aspectMethodIsFunction) {
                    throw new AspectTypeMismatchException(Resources.AspectEventParametersMismatach.Fmt(eventName));
                }

                argumentsType = aspectParameters[0].ParameterType;
                genericArguments = argumentsType.GetGenericArguments();

                if (methodIsFunction) {
                    var argumentsLength = 0;
                    Type aspectReturnType = null;

                    if (typeof(IEventActionInterceptionArgs).IsAssignableFrom(argumentsType)) {
                        throw new AspectAnnotationException(Resources.EventActionInterceptionAspcetMismatch);
                    }

                    if (genericArguments.Length == 0) {
                        throw new AspectTypeMismatchException(Resources.AspectReturnTypeMismatch.Fmt(eventName));
                    }

                    argumentsLength = genericArguments.Length - 1;
                    aspectReturnType = genericArguments[argumentsLength];

                    if (genericArguments.Length > 1) {
                        comparedTypes = genericArguments.Take(argumentsLength)
                                                        .ToArray();
                    }

                    if (!ValidateTypesAreEqual(invokeMethod.ReturnType, aspectReturnType)) {
                        throw new AspectTypeMismatchException(Resources.AspectReturnTypeMismatch.Fmt(eventName));
                    }
                }
                else {
                    comparedTypes = genericArguments;

                    if (typeof(IEventFunctionInterceptionArgs).IsAssignableFrom(argumentsType)) {
                        throw new AspectAnnotationException(Resources.EventActionInterceptionAspcetMismatch);
                    }
                }

                if (!ValidateParameters(methodParameters, comparedTypes)) {
                    throw new AspectTypeMismatchException(Resources.AspectEventParametersMismatach.Fmt(eventName));
                }
            });
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

        private static bool ValidateTypesAreEqual(Type memberType, Type aspectType) {
            return ReferenceEquals(memberType, aspectType);
        }
    }
}
