using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving;
using NCop.Core.Extensions;
using System;
using System.Linq;
using System.Reflection;

namespace NCop.Aspects.Extensions
{
    public static class AspectExtensions
    {
        internal static bool Is<TAspect>(this IAspect aspect) where TAspect : IAspect {
            return typeof(TAspect).IsAssignableFrom(aspect.GetType());
        }

        internal static bool IsMethodLevelAspect(this IAspect aspect) {
            var type = aspect.GetType();

            return typeof(OnMethodBoundaryAspectAttribute).IsAssignableFrom(type) ||
                   typeof(MethodInterceptionAspectAttribute).IsAssignableFrom(type) ||
                   typeof(GetPropertyInterceptionAspect).IsAssignableFrom(type) ||
                   typeof(SetPropertyInterceptionAspect).IsAssignableFrom(type);
        }

        internal static bool IsPropertyLevelAspect(this IAspect aspect) {
            var type = aspect.GetType();

            return typeof(PropertyInterceptionAspectAttribute).IsAssignableFrom(type) ||
                   typeof(GetPropertyInterceptionAspect).IsAssignableFrom(type) ||
                   typeof(SetPropertyInterceptionAspect).IsAssignableFrom(type);
        }

        internal static Type GetArgumentType(this IAspectDefinition aspectDefinition) {
            var aspectType = aspectDefinition.Aspect.AspectType;
            var overridenMethods = aspectType.GetOverridenMethods();
            var adviceMethod = overridenMethods[0];

            return adviceMethod.GetParameters()[0].ParameterType;
        }

        internal static Type ToAspectArgumentImpl(this IAspectDefinition aspectDefinition) {
            var methodAspectDefinition = aspectDefinition as IMethodAspectDefinition;

            if (methodAspectDefinition.IsNotNull()) {
                return methodAspectDefinition.ToAspectArgumentImpl();
            }

            return ((IPropertyAspectDefinition)aspectDefinition).ToAspectArgumentImpl();
        }

        internal static Type ToAspectArgumentImpl(this IMethodAspectDefinition aspectDefinition) {
            return aspectDefinition.ToAspectArgumentImpl(aspectDefinition.Method);
        }

        internal static Type ToAspectArgumentImpl(this IPropertyAspectDefinition aspectDefinition) {
            var property = aspectDefinition.Property;
            var method = aspectDefinition.IsGetPropertyAspectDefinition() ?
                                          property.GetGetMethod() :
                                          property.GetSetMethod();

            return aspectDefinition.ToAspectArgumentImpl(method);
        }

        private static Type ToAspectArgumentImpl(this IAspectDefinition aspectDefinition, MethodInfo method) {
            var declaringType = method.DeclaringType;
            var argumentType = aspectDefinition.GetArgumentType();
            var genericArguments = argumentType.GetGenericArguments();
            var genericArgumentsWithContext = new[] { declaringType }.Concat(genericArguments);

            return argumentType.MakeGenericArgsType(method, genericArgumentsWithContext.ToArray());
        }

        internal static Type ToAspectArgumentContract(this MethodInfo methodInfoImpl) {
            var isFunction = !ReferenceEquals(methodInfoImpl.ReturnType, typeof(void));

            var argumentTypes = methodInfoImpl.GetParameters().ToList(param => {
                var parameterType = param.ParameterType;
                return parameterType.IsByRef ? parameterType.GetElementType() : parameterType;
            });

            if (isFunction) {
                argumentTypes.Add(methodInfoImpl.ReturnType);
            }

            return argumentTypes.ToAspectArgumentContract(isFunction);
        }

        internal static Type ToPropertyAspectArgument(this MethodInfo methodInfoImpl) {
            var argumentTypes = methodInfoImpl.GetArguments();

            return typeof(PropertyInterceptionArgs<>).MakeGenericType(argumentTypes);
        }

        internal static Type ToPropertyArgumentContract(this MethodInfo methodInfoImpl) {
            var argumentTypes = methodInfoImpl.GetArguments();

            return typeof(IPropertyArg<>).MakeGenericType(argumentTypes);
        }

        private static Type[] GetArguments(this MethodInfo methodInfoImpl)
        {
            var argumentTypes = new Type[1];

            if (methodInfoImpl.ReturnType.IsNotNull() && !ReferenceEquals(methodInfoImpl.ReturnType, typeof(void))) {
                argumentTypes[0] = methodInfoImpl.ReturnType;
            }
            else {
                argumentTypes[0] = methodInfoImpl.GetParameters().First().ParameterType;
            }

            return argumentTypes;
        }

        internal static BindingSettings ToBindingSettings(this IAspectDefinition aspectDefinition) {
            var methodAspectDefinition = aspectDefinition as IMethodAspectDefinition;

            if (methodAspectDefinition.IsNotNull()) {
                return methodAspectDefinition.ToMethodBindingSettings();
            }

            return ((IPropertyAspectDefinition)aspectDefinition).ToPropertyBindingSettings();
        }

        private static BindingSettings ToMethodBindingSettings(this IAspectDefinition aspectDefinition) {
            var aspectArgumentType = aspectDefinition.GetArgumentType();
            var aspectArgumentImplType = aspectDefinition.ToAspectArgumentImpl();
            var genericArguments = aspectArgumentImplType.GetGenericArguments();

            if (aspectArgumentType.IsFunctionAspectArgs()) {
                return new BindingSettings {
                    IsFunction = true,
                    ArgumentType = aspectArgumentImplType,
                    BindingType = aspectArgumentType.MakeGenericFunctionBinding(genericArguments)
                };
            }

            return new BindingSettings {
                IsFunction = false,
                ArgumentType = aspectArgumentImplType,
                BindingType = aspectArgumentType.MakeGenericActionBinding(genericArguments)
            };
        }

        private static BindingSettings ToPropertyBindingSettings(this IPropertyAspectDefinition aspectDefinition) {
            var aspectArgumentType = aspectDefinition.GetArgumentType();
            var aspectArgumentImplType = aspectDefinition.ToAspectArgumentImpl();
            var genericArguments = aspectArgumentImplType.GetGenericArguments();

            return new BindingSettings {
                IsFunction = true,
                IsProperty = true,
                ArgumentType = aspectArgumentImplType,
                BindingType = aspectArgumentType.MakeGenericPropertyBinding(genericArguments)
            };
        }

        internal static ArgumentsWeavingSettings ToArgumentsWeavingSettings(this IAspectDefinition aspectDefinition) {
            return aspectDefinition.ToBindingSettings()
                                   .ToArgumentsWeavingSettings(aspectDefinition.Aspect.AspectType);
        }

        public static bool IsPropertyAspectDefinition(this IAspectDefinition aspectDefinition) {
            return aspectDefinition.IsGetPropertyAspectDefinition() ||
                   aspectDefinition.IsSetPropertyAspectDefinition();
        }

        public static bool IsGetPropertyAspectDefinition(this IAspectDefinition aspectDefinition) {
            return aspectDefinition.AspectType == AspectType.GetPropertyInterceptionAspect ||
                   aspectDefinition.AspectType == AspectType.GetPropertyFragmentInterceptionAspect;
        }

        public static bool IsSetPropertyAspectDefinition(this IAspectDefinition aspectDefinition) {
            return aspectDefinition.AspectType == AspectType.SetPropertyInterceptionAspect ||
                   aspectDefinition.AspectType == AspectType.SetPropertyFragmentInterceptionAspect;
        }

        internal static ArgumentsWeavingSettings ToArgumentsWeavingSettings(this BindingSettings bindingSettings, Type aspectType = null) {
            var methodParameters = bindingSettings.ToMethodParameters();

            return new ArgumentsWeavingSettings {
                AspectType = aspectType,
                IsProperty = bindingSettings.IsProperty,
                IsFunction = bindingSettings.IsFunction,
                ReturnType = methodParameters.ReturnType,
                Parameters = methodParameters.Parameters,
                ArgumentType = bindingSettings.ArgumentType,
                BindingsDependency = bindingSettings.BindingDependency
            };
        }

        internal static AspectWeavingSettingsImpl CloneWith(this IAspectWeavingSettings aspectWeavingSettings, Action<AspectWeavingSettingsImpl> cloneFunc) {
            var clonedAspectWeavingSettings = new AspectWeavingSettingsImpl {
                WeavingSettings = aspectWeavingSettings.WeavingSettings,
                AspectRepository = aspectWeavingSettings.AspectRepository,
                AspectArgsMapper = aspectWeavingSettings.AspectArgsMapper,
                LocalBuilderRepository = aspectWeavingSettings.LocalBuilderRepository,
                ByRefArgumentsStoreWeaver = aspectWeavingSettings.ByRefArgumentsStoreWeaver
            };

            cloneFunc(clonedAspectWeavingSettings);

            return clonedAspectWeavingSettings;
        }

        internal static MethodParameters ToMethodParameters(this BindingSettings bindingSettings) {
            var methodParameters = new MethodParameters();
            var arguments = bindingSettings.BindingType.GetGenericArguments();

            if (bindingSettings.IsFunction) {
                var length = arguments.Length - 2;

                methodParameters.ReturnType = arguments.Last();
                methodParameters.Parameters = new Type[length];
                Array.Copy(arguments, 1, methodParameters.Parameters, 0, length);
            }
            else {
                methodParameters.Parameters = arguments.Skip(1).ToArray();
            }

            return methodParameters;
        }

        internal static MethodParameters ToBindingMethodParameters(this BindingSettings bindingSettings) {
            Func<Type[], Type> argumentResolver = null;
            var methodParameters = new MethodParameters();
            var arguments = bindingSettings.BindingType.GetGenericArguments();

            methodParameters.Parameters = new Type[2];
            methodParameters.Parameters[0] = arguments[0].MakeByRefType();
            arguments = arguments.Skip(1).ToArray();

            if (bindingSettings.IsProperty) {
                methodParameters.ReturnType = arguments.Last();
                argumentResolver = typeArguments => {
                    return typeof(IPropertyArg<>).MakeGenericType(typeArguments);
                };
            }
            else if (bindingSettings.IsFunction) {
                methodParameters.ReturnType = arguments.Last();
                argumentResolver = AspectArgsContractResolver.ToFunctionAspectArgumentContract;
            }
            else {
                methodParameters.ReturnType = typeof(void);
                argumentResolver = AspectArgsContractResolver.ToActionAspectArgumentContract;
            }

            methodParameters.Parameters[1] = argumentResolver(arguments);

            return methodParameters;
        }
    }
}
