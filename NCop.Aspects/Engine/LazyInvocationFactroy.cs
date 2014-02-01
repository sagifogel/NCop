using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lib = NCop.Core.Lib;
using NCop.Core.Extensions;

namespace NCop.Aspects.Engine
{
    public static class LazyInvocationFactroy
    {
        public static Lib.Lazy<TInvocation> CreateInvocation<TInvocation>(object instance, MethodInfo method) {
            return new Lib.Lazy<TInvocation>(() => {
                return CreateExpression<TInvocation>(instance, method).Compile();
            });
        }

        private static Expression<TInvocation> CreateExpression<TInvocation>(object instance, MethodInfo method) {
            var parameters = method.GetParameters().Select(@param => param.ParameterType);
            var @paramExpressions = parameters.ToList(@param => Expression.Parameter(@param));

            return Expression.Lambda<TInvocation>(
                        Expression.Call(Expression.Constant(instance), method, @paramExpressions),
                            @paramExpressions);
        }
    }
}
