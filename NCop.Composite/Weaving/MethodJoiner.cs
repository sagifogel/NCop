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
            var joined = mixinsMap.Select(mixin => new {
                ContractType = mixin.ContractType,
                ImplementationType = mixin.ImplementationType,
                ContractMethods = mixin.ContractType.GetMethods(),
                ImplMethods = mixin.ImplementationType.GetMethods().ToSet()
            });

            Values = joined.Select(join => {
                var methods = join.ContractMethods;
                var result = methods.SelectFirst(join.ImplMethods,
                                                (c, impl) => MethodMatch(c, impl),
                                                (c, impl) => impl);

                return Tuple.Create(result, join.ImplementationType, join.ContractType);
            });
        }

        private static bool MethodMatch(MethodInfo firstMethod, MethodInfo secondMethod) {
            if (!firstMethod.Name.Equals(secondMethod.Name) || !MatchReturnType(firstMethod.ReturnType, secondMethod.ReturnType)) {
                return false;
            }

            return MatchParameters(firstMethod.GetParameters(), secondMethod.GetParameters());
        }

        private static bool MatchParameters(ParameterInfo[] firstParameters, ParameterInfo[] secondParameters) {
            if (firstParameters.Length != secondParameters.Length) {
                return false;
            }

            return firstParameters.All((p, i) => {
                return MatchParameter(p, secondParameters[i]);
            });
        }

        private static bool MatchReturnType(Type firstReturnType, Type secondReturnType) {
            return firstReturnType.Name.Equals(secondReturnType.Name) || IsGeneric(firstReturnType, secondReturnType);
        }

        private static bool MatchParameter(ParameterInfo firstParameter, ParameterInfo secondParameter) {
            var firstParameterType = firstParameter.ParameterType;
            var secondParameterType = secondParameter.ParameterType;

            return firstParameterType.Equals(secondParameterType) || IsGeneric(firstParameterType, secondParameterType);
        }

        private static bool IsGeneric(Type firstType, Type secondType) {
            bool typesCanNotBeCompared = firstType.IsGenericParameter || secondType.IsGenericParameter;

            if (!typesCanNotBeCompared) {
                firstType = GetGenericTypeOrSelfReference(firstType);

                if (firstType.IsGenericType) {
                    var firstArguments = secondType.GetGenericArguments();
                    var secondArguments = firstType.GetGenericArguments();
                    var elementType = firstType.GetElementType();

                    if (elementType.Equals(secondType) && firstArguments.Length == secondArguments.Length) {
                        return firstArguments.All((arg, i) => {
                            return IsGeneric(arg, secondArguments[i]);
                        });
                    }

                    return false;
                }

                if (secondType.HasElementType) {
                    Type elementType = null;

                    if (!secondType.IsByRef) {
                        return IsGeneric(firstType, secondType.GetElementType());
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

        internal static Type GetGenericTypeOrSelfReference(Type type) {
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