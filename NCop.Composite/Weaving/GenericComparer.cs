using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.Composite.Weaving
{
    internal static class GenericComparer
    {
        internal static bool Compare(Type firstType, Type secondType) {
            bool typesCanNotBeCompared = firstType.IsGenericParameter || secondType.IsGenericParameter;

            if (!typesCanNotBeCompared) {
                firstType = GetGenericTypeOrSelfReference(firstType);

                if (firstType.IsGenericType) {
                    var firstArguments = secondType.GetGenericArguments();
                    var secondArguments = firstType.GetGenericArguments();
                    var elementType = firstType.GetElementType();

                    if (elementType.Equals(secondType) && firstArguments.Length == secondArguments.Length) {
                        return firstArguments.All((arg, i) => {
                            return Compare(arg, secondArguments[i]);
                        });
                    }

                    return false;
                }

                if (secondType.HasElementType) {
                    Type elementType = null;

                    if (!secondType.IsByRef) {
                        return Compare(firstType, secondType.GetElementType());
                    }

                    do {
                        elementType = secondType.GetElementType();
                    }
                    while (elementType.HasElementType);

                    if (IsGeneric(elementType) || IsGeneric(firstType)) {
                        return true;
                    }
                }
            }

            return typesCanNotBeCompared || secondType.Equals(firstType);
        }

        private static bool IsGeneric(Type type) {
            return type.IsGenericParameter || type.IsGenericType || type.IsGenericTypeDefinition;
        }

        private static Type GetGenericTypeOrSelfReference(Type type) {
            Type element = type;

            if (type.IsGenericParameter || type.IsGenericType) {
                return type;
            }

            for (var self = element; self.HasElementType; self = element.GetElementType()) {
                element = self;
            }

            if (type.IsByRef && !IsGenericParameterOrType(element)) {
                return type;
            }

            return element;
        }

        private static bool IsGenericParameterOrType(Type genericType) {
            return genericType.IsGenericParameter || genericType.IsGenericType;
        }
    }
}
