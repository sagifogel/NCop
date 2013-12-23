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
    public static class AspectBuilderExtensions
    {
        public static bool Is<TAspect>(this IAspect aspect) where TAspect : IAspect {
            return typeof(TAspect).IsAssignableFrom(aspect.GetType());
        }

        public static bool IsMethodLevelAspect(this IAspect aspect) {
            var type = aspect.GetType();

            return typeof(OnMethodBoundaryAspectAttribute).IsAssignableFrom(type) ||
                   typeof(MethodInterceptionAspectAttribute).IsAssignableFrom(type);
        }

        public static Type GetArgumentType(this IAspectDefinition aspectDefinition) {
            var aspectType = aspectDefinition.Aspect.AspectType;
            var overridenMethods = aspectType.GetOverridenMethods();
            var adviceMethod = overridenMethods.First();

            return adviceMethod.GetParameters().First().ParameterType;
        }

        public static Type ToAspectArgumentImpl(this IAspectDefinition aspectDefinition, Type declaringType, Type aspectArgType = null) {
            var argumentType = aspectArgType ?? aspectDefinition.GetArgumentType();
            var genericArguments = argumentType.GetGenericArguments();
            var genericArgumentsWithContext = new[] { declaringType }.Concat(genericArguments);

            return argumentType.MakeGenericArgsType(genericArgumentsWithContext.ToArray());
        }

        public static BindingSettings ToBindingSettings(this IAspectDefinition aspectDefinition, Type declaringType) {
            var aspectArgumentType = aspectDefinition.GetArgumentType();
            var aspectArgumentImplType = aspectDefinition.ToAspectArgumentImpl(declaringType);
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

        public static ArgumentsWeavingSettings ToArgumentsWeavingSettings(this IAspectDefinition aspectDefinition, Type declaringType) {
            return aspectDefinition.ToBindingSettings(declaringType)
                                   .ToArgumentsWeavingSettings(aspectDefinition.Aspect.AspectType);
        }

        public static ArgumentsWeavingSettings ToArgumentsWeavingSettings(this BindingSettings bindingSettings, Type aspectType = null) {
            var methodParameters = bindingSettings.ToMethodParameters();

            return new ArgumentsWeavingSettings {
                AspectType = aspectType,
                IsFunction = bindingSettings.IsFunction,
                ArgumentType = bindingSettings.ArgumentType,
                Parameters = methodParameters.Parameters
            };
        }

        public static MethodParameters ToMethodParameters(this BindingSettings bindingSettings) {
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
