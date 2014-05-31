using NCop.Composite.Framework;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.IoC;
using NCop.IoC.Fluent;
using NCop.IoC.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using NCop.IoC.Extensions;

namespace NCop.Composite.IoC
{
    internal class CompositeFrameworkRegistration : IRegistration
    {
        private readonly Type serviceType = null;
        private readonly Type concreteType = null;
        private readonly IEnumerable<TypeMap> dependencies = null;
        private readonly CompositeRegistration registration = null;
        private readonly IRegistrationResolver registrationResolver = null;

        internal CompositeFrameworkRegistration(IRegistrationResolver registrationResolver, Type concreteType, Type serviceType, IEnumerable<TypeMap> dependencies = null, Type castTo = null, string name = null) {
            NamedAttribute namedAttribute = null;

            this.serviceType = serviceType;
            this.concreteType = concreteType;
            this.dependencies = dependencies;
            this.registrationResolver = registrationResolver;

            registration = new CompositeRegistration {
                ServiceType = castTo ?? serviceType,
                FactoryType = MakeFactoryType(castTo ?? serviceType)
            };

            if (IsSingletonComposite()) {
                registration.Scope = ReuseScope.Hierarchy;
            }

            registration.Name = name;

            if (TryGetNamedAttribute(out namedAttribute)) {
                registration.Name = name + namedAttribute.Name;
            }

            As(concreteType);
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

        public virtual ReuseScope Scope {
            get {
                return registration.Scope;
            }
        }

        public virtual Owner Owner {
            get {
                return registration.Owner;
            }
        }

        public void As(Type castTo) {
            var typeofService = typeof(object);
            var containerParamater = Expression.Parameter(typeof(INCopDependencyResolver), "container");
            var tryResolveMethodInfo = typeof(INCopDependencyResolver).GetMethod("TryResolve", Type.EmptyTypes);
            var dependencyAware = typeofService.IsDefined<DependencyAware>();

            var properties = castTo.GetPublicProperties()
                                   .Where(prop => prop.CanWrite)
                                   .Where(prop => !prop.PropertyType.IsValueType)
                                   .Where(prop => !prop.PropertyType.Equals(typeof(string)))
                                   .Where(prop => !dependencyAware && !prop.IsDefined<IgnoreDependency>() ||
                                                  dependencyAware && prop.IsDefined<DependencyAttribute>());

            var assignments = properties.Select(prop => {
                var propertyType = prop.PropertyType;
                var methodCallExpression = MethodCallExpression(tryResolveMethodInfo, propertyType, containerParamater);

                return Expression.Bind(prop, methodCallExpression);
            });

            var newExpression = NewExpression(castTo, containerParamater);
            var lambda = Expression.Lambda(
                            Expression.MemberInit(newExpression, assignments.ToArray()),
                                  containerParamater);

            registration.Func = lambda.Compile();
        }

        protected NewExpression NewExpression(Type type, ParameterExpression instance) {
            IDictionary<Type, Type> dependencyMap = null;
            var ctorResolveMethodInfo = typeof(INCopDependencyResolver).GetMethod("Resolve", Type.EmptyTypes);
            var ctorResolveNamedMethodInfo = typeof(INCopDependencyResolver).GetMethod("ResolveNamed");
            var ctor = type.GetSingleConstructorOrAnnotated();
            var ctorParameters = ctor.GetParameters();

            if (ctorParameters.Length > 0) {
                dependencyMap = dependencies.ToDictionary(dependency => dependency.ContractType,
                                                          dependency => dependency.ImplementationType);
            }

            var @params = ctorParameters.Select(pi => {
                var parameterType = pi.ParameterType;
                var registeredType = dependencyMap[parameterType];
                var registration = registrationResolver.Resolve(registeredType);

                if (registration.Name.IsNotNullOrEmpty()) {
                    return ResolveNamedMethodCallExpression(registration.Name, ctorResolveNamedMethodInfo, parameterType, instance);
                }

                return MethodCallExpression(ctorResolveMethodInfo, parameterType, instance);
            });

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

        private bool IsSingletonComposite() {
            return concreteType.IsDefined<SingletonCompositeAttribute>() ||
                   serviceType.IsDefined<SingletonCompositeAttribute>();
        }

        private bool TryGetNamedAttribute(out NamedAttribute namedAttribute) {
            namedAttribute = concreteType.GetCustomAttribute<NamedAttribute>() ??
                             serviceType.GetCustomAttribute<NamedAttribute>();

            return namedAttribute.IsNotNull();
        }
    }
}
