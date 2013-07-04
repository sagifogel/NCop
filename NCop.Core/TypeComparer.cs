using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.Core
{
	public static class TypeComparer
	{
		public static bool Compare(Type firstType, Type secondType) {
			if (firstType.IsGenericType && secondType.IsGenericType) {
				Tuple<Type, Type> tupleArgs = null;
				var firstGenericDefinition = firstType.GetGenericTypeDefinition();
				var secondGenericDefinition = secondType.GetGenericTypeDefinition();
				var firstGenericAguments = secondGenericDefinition.GetGenericArguments();
				var firstArguments = secondType.GetGenericArguments();
				var secondArguments = firstType.GetGenericArguments();
				var arguments = firstGenericAguments.Select((arg, i) => {
					var covariantAttr = arg.GenericParameterAttributes & GenericParameterAttributes.Covariant;

					return new {
						Position = i,
						Type = arg,
						IsCovariant = covariantAttr == GenericParameterAttributes.Covariant
					};
				});
				
				if (firstArguments.Length != secondArguments.Length) {
					return false;
				}

				return arguments.All(arg => {
					if (arg.IsCovariant) {
						return firstArguments[arg.Position].IsAssignableFrom(secondArguments[arg.Position]);
					}

					return Compare(firstArguments[arg.Position], secondArguments[arg.Position]);
				});
			}

			if (firstType.HasElementType && secondType.HasElementType) {
				Type firstElementType = firstType.GetElementType();
				Type secondElementType = secondType.GetElementType();

				return Compare(firstElementType, secondElementType);
			}

			return secondType.Equals(firstType);
		}
	}
}
