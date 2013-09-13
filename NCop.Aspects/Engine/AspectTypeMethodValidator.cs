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
			Type[] genericArguments = null;
			var aspectType = aspect.AspectType;
			Type[] comparedTypes = Type.EmptyTypes;
			ParameterInfo[] methodParameters = null;
			ParameterInfo[] aspectParameters = null;
			var overridenMethods = aspectType.GetOverridenMethods();

			if (overridenMethods.Length == 0) {
				throw new AdviceNotFoundException(aspect.GetType());
			}

			method = overridenMethods[0];
			aspectParameters = method.GetParameters();

			if (aspectParameters.Length == 0) {
				throw new AspectTypeMismatchException(Resources.AspectParametersMismatach.Fmt(methodInfo.Name));
			}

			methodParameters = methodInfo.GetParameters();
			genericArguments = aspectParameters[0].ParameterType.GetGenericArguments();

			if (methodInfo.HasReturnType()) {
				int argumentsLength = 0;
				Type aspectReturnType = null;

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
			}

			if (!ValidateParameters(methodParameters, comparedTypes)) {
				throw new AspectTypeMismatchException(Resources.AspectParametersMismatach.Fmt(methodInfo.Name));
			}
		}

		private static bool ValidateParameters(ParameterInfo[] methodParameters, Type[] comparedTypes) {
			return methodParameters.Length == comparedTypes.Length &&
				   methodParameters.All((p, i) => {
					   return p.ParameterType.Equals(comparedTypes[i]);
				   });
		}

		private static bool ValidateReturnType(Type methodReturnType, Type aspectReturnType) {
			return methodReturnType.Equals(aspectReturnType);
		}
	}
}
