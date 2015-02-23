using System;
using System.Linq;
using System.Reflection;

namespace NCop.Core
{
    public static class TypeComparer
    {
        public static bool Compare(Type firstType, Type secondType) {
            if (firstType.IsGenericType && secondType.IsGenericType) {
                var firstGenericDefinition = firstType.GetGenericTypeDefinition();
                var firstGenericArguments = firstGenericDefinition.GetGenericArguments();
                var firstArguments = firstType.GetGenericArguments();
                var secondArguments = secondType.GetGenericArguments();

                var arguments = firstGenericArguments.Select((arg, i) => {
                    var covariantAttr = arg.GenericParameterAttributes & GenericParameterAttributes.Covariant;

                    return new {
                        Type = arg,
                        Position = i,
                        IsCovariant = covariantAttr == GenericParameterAttributes.Covariant,
                    };
                });

                if (firstArguments.Length != secondArguments.Length) {
                    return false;
                }

                return arguments.All(arg => {
                    if (arg.IsCovariant) {
                        return secondArguments[arg.Position].IsAssignableFrom(firstArguments[arg.Position]);
                    }

                    return Compare(firstArguments[arg.Position], secondArguments[arg.Position]);
                });
            }

            if (firstType.HasElementType && secondType.HasElementType) {
                var firstElementType = firstType.GetElementType();
                var secondElementType = secondType.GetElementType();

                return Compare(firstElementType, secondElementType);
            }

            return ReferenceEquals(secondType, firstType);
        }
    }
}
