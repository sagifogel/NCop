using NCop.Composite.Framework;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.IoC;
using NCop.IoC.Extensions;
using NCop.IoC.Fluent;
using NCop.IoC.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NCop.Composite.IoC
{
    internal class CompositeFrameworkRegistration : IRegistration
    {
        private readonly Type serviceType = null;
        private readonly Type concreteType = null;
        private readonly IEnumerable<TypeMap> dependencies = null;
        private readonly CompositeRegistration registration = null;
        private readonly IRegistrationResolver registrationResolver = null;

        internal CompositeFrameworkRegistration(IRegistrationResolver registrationResolver, Type concreteType, Type serviceType, IEnumerable<TypeMap> dependencies, Type castTo, string name, bool disposable) {
            NamedAttribute namedAttribute = null;

            this.serviceType = serviceType;
            this.concreteType = concreteType;
            this.dependencies = dependencies;
            this.registrationResolver = registrationResolver;

            registration = new CompositeRegistration {
                ServiceType = castTo ?? serviceType,
                FactoryType = MakeFactoryType(castTo ?? serviceType)
            };

            SetLifetime();

            registration.Name = name;

            if (name.IsNullOrEmpty() && TryGetNamedAttribute(out namedAttribute)) {
                registration.Name = namedAttribute.Name;
            }

            if (disposable) {
                registration.OwnedByContainer();
            }

            As(concreteType, false);
        }

        public virtual string Name {
            get {
                return registration.Name;
            }
        }

        public virtual Type CastTo {
            get {
                return registration.CastTo;
            }
        }

        public virtual Delegate Func {
            get {
                if (registration.Func.IsNull()) {
                    As(registration.CastTo = ServiceType);
                }

                return registration.Func;
            }
        }

        public virtual Type FactoryType {
            get {
                return registration.FactoryType;
            }
        }

        public virtual Type ServiceType {
            get {
                return registration.ServiceType;
            }
        }

        public virtual Lifetime Lifetime {
            get {
                return registration.Lifetime;
            }
        }

        public virtual Owner Owner {
            get {
                return registration.Owner;
            }
        }

        public void As(Type castTo, bool resolveDependenyProperties = true) {
            LambdaExpression lambda = null;
            NewExpression newExpression = null;
            var typeofService = typeof(object);
            var assignments = Enumerable.Empty<MemberBinding>();
            var containerParamater = Expression.Parameter(typeof(INCopDependencyResolver), "container");
            var tryResolveMethodInfo = typeof(INCopDependencyResolver).GetMethod("TryResolve", Type.EmptyTypes);
            var dependencyAware = typeofService.IsDefined<DependencyAwareAttribute>();

            if (resolveDependenyProperties) {
                var properties = castTo.GetPublicProperties()
                                       .Where(prop => prop.CanWrite)
                                       .Where(prop => !prop.PropertyType.IsValueType)
                                       .Where(prop => !ReferenceEquals(prop.PropertyType, typeof(string)))
                                       .Where(prop => !dependencyAware && !prop.IsDefined<IgnoreDependencyAttribute>() ||
                                                      dependencyAware && prop.IsDefined<DependencyAttribute>());

                assignments = properties.Select(prop => {
                    var propertyType = prop.PropertyType;
                    var methodCallExpression = MethodCallExpression(tryResolveMethodInfo, propertyType, containerParamater);

                    return Expression.Bind(prop, methodCallExpression);
                });
            }

            newExpression = NewExpression(castTo, containerParamater);
            lambda = Expression.Lambda(
                        Expression.MemberInit(newExpression, assignments.ToArray()),
                                containerParamater);

            registration.Func = lambda.Compile();
        }

        protected NewExpression NewExpression(Type type, ParameterExpression instance) {
            var @params = Enumerable.Empty<Expression>();
            var ctorResolveMethodInfo = typeof(INCopDependencyResolver).GetMethod("Resolve", Type.EmptyTypes);
            var ctorResolveNamedMethodInfo = typeof(INCopDependencyResolver).GetMethod("ResolveNamed");
            var ctor = type.GetSingleConstructorOrAnnotated();
            var ctorParameters = ctor.GetParameters();

            if (ctorParameters.Length > 0) {
                var dependencyMap = dependencies.ToDictionary(dependency => dependency.ContractType, dependency => dependency.ImplementationType);

                @params = ctorParameters.Select(pi => {
                    Type registeredType;
                    var parameterType = pi.ParameterType;

                    if (dependencyMap.TryGetValue(parameterType, out registeredType)) {
                        var resolvedRegistration = registrationResolver.Resolve(registeredType);

                        if (resolvedRegistration.Name.IsNotNullOrEmpty()) {
                            return ResolveNamedMethodCallExpression(resolvedRegistration.Name, ctorResolveNamedMethodInfo, parameterType, instance);
                        }
                    }

                    return MethodCallExpression(ctorResolveMethodInfo, parameterType, instance);
                });
            }

            return Expression.New(ctor, @params.ToArray());
        }

        protected MethodCallExpression MethodCallExpression(MethodInfo methodInfo, Type parameterType, ParameterExpression instance) {
            var method = methodInfo.MakeGenericMethod(parameterType);

            return Expression.Call(instance, method);
        }

        protected MethodCallExpression ResolveNamedMethodCallExpression(string name, MethodInfo methodInfo, Type parameterType, ParameterExpression instance) {
            var method = methodInfo.MakeGenericMethod(parameterType);

            return Expression.Call(instance, method, Expression.Constant(name));
        }

        public virtual void Named(string name) {
            registration.Named(name);
        }

        private static Type MakeFactoryType(Type serviceType) {
            return typeof(Func<,>).MakeGenericType(typeof(INCopDependencyResolver), serviceType);
        }

        private void SetLifetime() {
            var types = new[] { concreteType, serviceType };

            if (types.AnyHasAttribute<PerThreadCompositeAttribute>()) {
                registration.PerThread();
                return;
            }

            if (types.AnyHasAttribute<SingletonCompositeAttribute>()) {
                registration.WithinHierarchy();
                return;
            }

            if (types.AnyHasAttribute<PerHttpRequestCompositeAttribute>()) {
                registration.PerHttpRequest();
            }
        }

        private bool TryGetNamedAttribute(out NamedAttribute namedAttribute) {
            namedAttribute = concreteType.GetCustomAttribute<NamedAttribute>() ??
                             serviceType.GetCustomAttribute<NamedAttribute>();

            return namedAttribute.IsNotNull();
        }
    }
}
