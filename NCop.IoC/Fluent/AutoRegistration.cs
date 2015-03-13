using NCop.Core.Extensions;
using NCop.IoC.Extensions;
using NCop.IoC.Framework;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NCop.IoC.Fluent
{
	public class AutoRegistration<TService> : CastableRegistration<TService>
	{
		public AutoRegistration(Type serviceType, Type factoryType)
			: base(serviceType, factoryType) {
		}

		protected override ICasted As(Type castTo) {
			var typeofService = typeof(TService);
			var containerParamater = Expression.Parameter(typeof(INCopDependencyResolver), "container");
			var tryResolveMethodInfo = typeof(INCopDependencyResolver).GetMethod("TryResolve", Type.EmptyTypes);
			var dependencyAware = typeofService.IsDefined<DependencyAware>();
			var properties = castTo.GetPublicProperties()
								   .Where(prop => prop.CanWrite)
								   .Where(prop => !prop.PropertyType.IsValueType)
								   .Where(prop => !ReferenceEquals(prop.PropertyType, typeof(string)))
								   .Where(prop => !dependencyAware && !prop.IsDefined<IgnoreDependency>() ||
												  dependencyAware && prop.IsDefined<DependencyAttribute>());

			var assignments = properties.Select(prop => {
				var type = prop.PropertyType;
				var methodCallExpression = MethodCallExpression(tryResolveMethodInfo, type, containerParamater);

				return Expression.Bind(prop, methodCallExpression);
			});

			var ctorResolveMethodInfo = typeof(INCopDependencyResolver).GetMethod("Resolve", Type.EmptyTypes);
			var newExpression = NewExpression(ctorResolveMethodInfo, castTo, containerParamater);
			var lambda = Expression.Lambda(
							Expression.MemberInit(newExpression, assignments.ToArray()),
								  containerParamater);

			Registration.Func = lambda.Compile();

			return this;
		}

		private NewExpression NewExpression(MethodInfo method, Type type, ParameterExpression instance) {
			var ctor = type.GetSingleConstructorOrAnnotated();
			var @params = ctor.GetParameters()
							  .Select(pi => {
								  return MethodCallExpression(method, pi.ParameterType, instance);
							  });

			return Expression.New(ctor, @params.ToArray());
		}

		private MethodCallExpression MethodCallExpression(MethodInfo method, Type parameterType, ParameterExpression instance) {
			var genericMethod = method.MakeGenericMethod(parameterType);

            return Expression.Call(instance, genericMethod);
		}
	}
}
