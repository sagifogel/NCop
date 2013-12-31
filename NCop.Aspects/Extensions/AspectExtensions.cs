using NCop.Aspects.Aspects;
using NCop.Aspects.Aspects.Builders;
using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;
using NCop.Aspects.Weaving;

namespace NCop.Aspects.Extensions
{
    internal static class AspectExtensions
    {
        internal static bool Is<TAspect>(this IAspect aspect) where TAspect : IAspect {
            return typeof(TAspect).IsAssignableFrom(aspect.GetType());
        }

        internal static bool IsMethodLevelAspect(this IAspect aspect) {
            var type = aspect.GetType();

            return typeof(OnMethodBoundaryAspectAttribute).IsAssignableFrom(type) ||
                   typeof(MethodInterceptionAspectAttribute).IsAssignableFrom(type);
        }

        internal static Type GetArgumentType(this IAspectDefinition aspectDefinition) {
            var aspectType = aspectDefinition.Aspect.AspectType;
            var overridenMethods = aspectType.GetOverridenMethods();
            var adviceMethod = overridenMethods.First();

            return adviceMethod.GetParameters().First().ParameterType;
        }

        internal static Type ToAspectArgumentImpl(this IAspectDefinition aspectDefinition) {
            var argumentType = aspectDefinition.GetArgumentType();
            var declaringType = aspectDefinition.Member.DeclaringType;
            var genericArguments = argumentType.GetGenericArguments();
            var genericArgumentsWithContext = new[] { declaringType }.Concat(genericArguments);

            return argumentType.MakeGenericArgsType(genericArgumentsWithContext.ToArray());
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

        internal static AspectWeavingSettings CloneWith(this IAspectWeavingSettings aspectWeavingSettings, Action<AspectWeavingSettings> cloneFunc) {
            var clonedAspectWeavingSettings = new AspectWeavingSettings {
                WeavingSettings = aspectWeavingSettings.WeavingSettings,
                AspectRepository = aspectWeavingSettings.AspectRepository,
                AspectArgsMapper = aspectWeavingSettings.AspectArgsMapper,
                LocalBuilderRepository = aspectWeavingSettings.LocalBuilderRepository
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
                arguments.Skip(1).ToArray();
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
                argumentResolver = AspectArgsContractResolver.ToFunctionAspectArgument;
            }
            else {
                argumentResolver = AspectArgsContractResolver.ToActionAspectArgument;
            }

            methodParameters.Parameters[1] = argumentResolver(arguments);

            return methodParameters;
        }
    }
}
