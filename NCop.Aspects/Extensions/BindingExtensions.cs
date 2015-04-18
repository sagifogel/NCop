using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Extensions
{
    public static class BindingExtensions
    {
        internal static Type MakeGenericFunctionBinding(this Type argumentsType, params Type[] typeArguments) {
            int parametersCount = argumentsType.GetGenericArguments().Length;

            return MethodBindingResolver.FuncionBindingMap[parametersCount].MakeGenericType(typeArguments);
        }

        internal static Type MakeGenericActionBinding(this Type argumentsType, params Type[] typeArguments) {
            int parametersCount = argumentsType.GetGenericArguments().Length;

            return MethodBindingResolver.ActionBindingMap[parametersCount].MakeGenericType(typeArguments);
        }

        internal static Type MakeGenericPropertyBinding(this Type argumentsType, params Type[] typeArguments) {
            return typeof(IPropertyBinding<,>).MakeGenericType(typeArguments);
        }
    }
}
