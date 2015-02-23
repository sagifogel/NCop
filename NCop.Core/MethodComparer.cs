using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Core
{
    public static class MethodComparer
    {
        public static bool IsMatchedTo(this MethodInfo firstMethod, MethodInfo secondMethod) {
            if (secondMethod.IsNull() || !firstMethod.Name.Equals(secondMethod.Name) || !MatchReturnType(firstMethod.ReturnType, secondMethod.ReturnType)) {
                return false;
            }

            return MatchParameters(firstMethod.GetParameters(), secondMethod.GetParameters());
        }

        public static bool MatchParameters(ParameterInfo[] firstParameters, ParameterInfo[] secondParameters) {
            if (firstParameters.Length != secondParameters.Length) {
                return false;
            }

            return firstParameters.All((p, i) => {
                return MatchParameter(p, secondParameters[i]);
            });
        }

        public static bool MatchReturnType(Type firstReturnType, Type secondReturnType) {
            return firstReturnType.Name.Equals(secondReturnType.Name) || TypeComparer.Compare(firstReturnType, secondReturnType);
        }

        public static bool MatchParameter(ParameterInfo firstParameter, ParameterInfo secondParameter) {
            var firstParameterType = firstParameter.ParameterType;
            var secondParameterType = secondParameter.ParameterType;

            return ReferenceEquals(firstParameterType, secondParameterType) || TypeComparer.Compare(firstParameterType, secondParameterType);
        }
    }
}
