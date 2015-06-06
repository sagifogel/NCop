using System;
using System.Linq;
using NCop.Aspects.Engine;
using System.Collections.Generic;

namespace NCop.Aspects.Extensions
{
    public static class BindingExtensions
    {   
        internal static Type MakeGenericFunctionBinding(this Type argumentsType, params Type[] typeArguments) {
            int parametersCount = argumentsType.GetGenericArguments().Length;

            return MethodBindingResolver.FunctionMap[parametersCount].MakeGenericType(typeArguments);
        }

        internal static Type MakeGenericActionBinding(this Type argumentsType, params Type[] typeArguments) {
            int parametersCount = argumentsType.GetGenericArguments().Length;

            return MethodBindingResolver.ActionMap[parametersCount].MakeGenericType(typeArguments);
        }

        internal static Type MakeEventGenericFunctionBinding(this Type argumentsType, params Type[] typeArguments) {
            int parametersCount = argumentsType.GetGenericArguments().Length;

            return EventBindingResolver.FunctionMap[parametersCount].MakeGenericType(typeArguments);
        }

        internal static Type MakeEventGenericActionBinding(this Type argumentsType, params Type[] typeArguments) {
            int parametersCount = argumentsType.GetGenericArguments().Length;

            return EventBindingResolver.ActionMap[parametersCount].MakeGenericType(typeArguments);
        }

        internal static Type MakeGenericFunctionAspectArgsEvent(this Type argumentsType, params Type[] typeArguments) {
            var typeArray = new Type[typeArguments.Length + 1];

            typeArray[0] = argumentsType;
            typeArguments.CopyTo(typeArray, 1);

            return AspectArgsImplResolver.FuncEventArgsMap[typeArguments.Length].MakeGenericType(typeArray);
        }

        internal static Type MakeGenericActionAspectArgsEvent(this Type argumentsType, params Type[] typeArguments) {
            var typeArray = new Type[typeArguments.Length + 1];

            typeArray[0] = argumentsType;
            typeArguments.CopyTo(typeArray, 1);

            return AspectArgsImplResolver.ActionEventArgsMap[typeArguments.Length].MakeGenericType(typeArray);
        }

        internal static Type MakeGenericPropertyBinding(this Type argumentsType, params Type[] typeArguments) {
            return typeof(IPropertyBinding<,>).MakeGenericType(typeArguments);
        }

        internal static Type MakeGenericEventBrokerBaseClassActionType(this Type decalringType, params Type[] typeArguments) {
            return MakeGenericEventBrokerBaseClass(decalringType, (parametersCount) => EventBrokerBaseClassResolver.ActionMap[parametersCount], typeArguments);
        }

        internal static Type MakeGenericEventBrokerBaseClassFunctionBinding(this Type decalringType, params Type[] typeArguments) {
            return MakeGenericEventBrokerBaseClass(decalringType, (parametersCount) => EventBrokerBaseClassResolver.FunctionMap[parametersCount], typeArguments);
        }

        private static Type MakeGenericEventBrokerBaseClass(this Type decalringType, Func<int, Type> genericTypeResolver, params Type[] typeArguments) {
            int parametersCount = typeArguments.Length;
            var eventBrokerTypeList = new List<Type> { decalringType };

            eventBrokerTypeList.AddRange(typeArguments);
            return genericTypeResolver(parametersCount).MakeGenericType(eventBrokerTypeList.ToArray());
        }
    }
}
