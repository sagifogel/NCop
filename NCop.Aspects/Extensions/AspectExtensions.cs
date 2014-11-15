using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
using NCop.Aspects.Weaving;
using NCop.Core.Extensions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using NCop.Weaving;

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
                   typeof(MethodInterceptionAspectAttribute).IsAssignableFrom(type);
        }

        internal static bool IsPropertyLevelAspect(this IAspect aspect) {
            var type = aspect.GetType();

            return typeof(PropertyInterceptionAspectAttribute).IsAssignableFrom(type);
        }

        internal static Type GetArgumentType(this IAspectDefinition aspectDefinition) {
            var aspectType = aspectDefinition.Aspect.AspectType;
            var overridenMethods = aspectType.GetOverridenMethods();
            var adviceMethod = overridenMethods[0];

            return adviceMethod.GetParameters()[0].ParameterType;
        }

        internal static Type ToAspectArgumentImpl(this IAspectDefinition aspectDefinition) {
            var argumentType = aspectDefinition.GetArgumentType();
            var declaringType = aspectDefinition.Member.DeclaringType;
            var genericArguments = argumentType.GetGenericArguments();
            var genericArgumentsWithContext = new[] { declaringType }.Concat(genericArguments);

            return argumentType.MakeGenericArgsType(genericArgumentsWithContext.ToArray());
        }

        internal static Type ToAspectArgumentContract(this MethodInfo methodInfoImpl) {
            var isFunction = !methodInfoImpl.ReturnType.Equals(typeof(void));

            var argumentTypes = methodInfoImpl.GetParameters().ToList(param => {
                var parameterType = param.ParameterType;
                return parameterType.IsByRef ? parameterType.GetElementType() : parameterType;
            });

            if (isFunction) {
                argumentTypes.Add(methodInfoImpl.ReturnType);
            }

            return argumentTypes.ToAspectArgumentContract(isFunction);
        }

        internal static BindingSettings ToBindingSettings(this IAspectDefinition aspectDefinition) {
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

        internal static ArgumentsWeavingSettings ToArgumentsWeavingSettings(this IAspectDefinition aspectDefinition) {
            return aspectDefinition.ToBindingSettings()
                                   .ToArgumentsWeavingSettings(aspectDefinition.Aspect.AspectType);
        }

        internal static ArgumentsWeavingSettings ToArgumentsWeavingSettings(this BindingSettings bindingSettings, Type aspectType = null) {
            Type bindingsDependencyType = null;
            var methodParameters = bindingSettings.ToMethodParameters();

            if (bindingSettings.BindingDependency.IsNotNull()) {
                bindingsDependencyType = bindingSettings.BindingDependency.FieldType;
            }

            return new ArgumentsWeavingSettings {
                AspectType = aspectType,
                IsFunction = bindingSettings.IsFunction,
                ReturnType = methodParameters.ReturnType,
                Parameters = methodParameters.Parameters,
                ArgumentType = bindingSettings.ArgumentType,
                BindingsDependency = bindingSettings.BindingDependency
            };
        }

        internal static AspectMethodWeavingSettingsImpl CloneWith(this IAspectMethodWeavingSettings aspectWeavingSettings, Action<AspectMethodWeavingSettingsImpl> cloneFunc) {
            var clonedAspectWeavingSettings = new AspectMethodWeavingSettingsImpl {
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
                var last = arguments.Last();
                int length = arguments.Length - 2;

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

            if (bindingSettings.IsFunction) {
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

        public static IAspectMethodWeavingSettings ToGetPropertyAspectWeavingSettings(this IAspectPropertyWeavingSettings aspectWeavingSettings) {
            var methodInfoImpl = aspectWeavingSettings.WeavingSettings.PropertyInfoImpl.GetGetMethod();

            return aspectWeavingSettings.ToMethodAspectWeavingSettings(methodInfoImpl);
        }

        public static IAspectMethodWeavingSettings ToSetPropertyAspectWeavingSettings(this IAspectPropertyWeavingSettings aspectWeavingSettings) {
            var methodInfoImpl = aspectWeavingSettings.WeavingSettings.PropertyInfoImpl.GetSetMethod();

            return aspectWeavingSettings.ToMethodAspectWeavingSettings(methodInfoImpl);
        }

        private static IAspectMethodWeavingSettings ToMethodAspectWeavingSettings(this IAspectPropertyWeavingSettings aspectWeavingSettings, MethodInfo methodInfoImpl) {
            var weavingSettings = aspectWeavingSettings.WeavingSettings;
            var methodWeavingSettings = new MethodWeavingSettings(methodInfoImpl,
                                                                  weavingSettings.ImplementationType,
                                                                  weavingSettings.ContractType,
                                                                  weavingSettings.TypeDefinition);

            return new AspectMethodWeavingSettingsImpl {
                WeavingSettings = methodWeavingSettings,
                AspectArgsMapper = aspectWeavingSettings.AspectArgsMapper,
                AspectRepository = aspectWeavingSettings.AspectRepository,
                LocalBuilderRepository = aspectWeavingSettings.LocalBuilderRepository,
                ByRefArgumentsStoreWeaver = aspectWeavingSettings.ByRefArgumentsStoreWeaver,
            };
        }
    }
}
