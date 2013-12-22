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
	}
}
