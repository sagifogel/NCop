using NCop.Aspects.Aspects;
using NCop.Core;
using NCop.Mixins.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Core.Extensions;
using System.Collections;

namespace NCop.Composite.Weaving
{
	internal class MethodJoiner : Tuples<MethodInfo, Type, Type>
	{
		internal MethodJoiner(IMixinsMap mixinsMap) {
			Func<MethodInfo, bool> methodPredicate = (methodInfo) => {
				return !methodInfo.IsSpecialName;
			};

			var joined = mixinsMap.Select(mixin => new {
				ContractType = mixin.ContractType,
				ImplementationType = mixin.ImplementationType,
				ContractMethods = mixin.ContractType.GetMethods().Where(methodPredicate),
				ImplMethods = mixin.ImplementationType.GetMethods().ToSet(methodPredicate)
			});

			Values = joined.SelectMany(join => {
				var methods = join.ContractMethods;

				return methods.Select(method => {
					var result = method.SelectFirst(join.ImplMethods,
												   (c, impl) => MethodMatch(c, impl),
												   (c, impl) => impl);

					return Tuple.Create(result, join.ImplementationType, join.ContractType);
				});
			});
		}

		protected static bool MethodMatch(MethodInfo firstMethod, MethodInfo secondMethod) {
			if (!firstMethod.Name.Equals(secondMethod.Name) || !MatchReturnType(firstMethod.ReturnType, secondMethod.ReturnType)) {
				return false;
			}

			return MatchParameters(firstMethod.GetParameters(), secondMethod.GetParameters());
		}

		protected static bool MatchParameters(ParameterInfo[] firstParameters, ParameterInfo[] secondParameters) {
			if (firstParameters.Length != secondParameters.Length) {
				return false;
			}

			return firstParameters.All((p, i) => {
				return MatchParameter(p, secondParameters[i]);
			});
		}

		protected static bool MatchReturnType(Type firstReturnType, Type secondReturnType) {
			return firstReturnType.Name.Equals(secondReturnType.Name) || TypeComparer.Compare(firstReturnType, secondReturnType);
		}

		protected static bool MatchParameter(ParameterInfo firstParameter, ParameterInfo secondParameter) {
			var firstParameterType = firstParameter.ParameterType;
			var secondParameterType = secondParameter.ParameterType;

			return firstParameterType.Equals(secondParameterType) || TypeComparer.Compare(firstParameterType, secondParameterType);
		}
	}
}