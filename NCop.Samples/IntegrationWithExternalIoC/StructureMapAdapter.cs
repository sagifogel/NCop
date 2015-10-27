using NCop.Core;
using NCop.Core.Extensions;
using NCop.IoC;
using StructureMap;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NCop.Samples.IntegrationWithExternalIoC
{
    public class StructureMapAdapter : INCopDependencyContainerAdapter
    {
        private readonly IContainer container = null;

        public StructureMapAdapter()
            : this(ObjectFactory.Container) {
        }

        public StructureMapAdapter(IContainer container) {
            this.container = container;
        }

        public void Configure() { }

        public TService Resolve<TService>() {
            return container.GetInstance<TService>();
        }

        public TService TryResolve<TService>() {
            return container.TryGetInstance<TService>();
        }

        public TService ResolveNamed<TService>(string name) {
            return container.GetInstance<TService>(name);
        }

        public TService TryResolveNamed<TService>(string name) {
            return container.TryGetInstance<TService>(name);
        }

        public void Dispose() {
            container.Dispose();
        }

        public INCopDependencyContainer CreateChildContainer() {
            return new StructureMapAdapter(container.GetNestedContainer());
        }

        public void Register(TypeMap typeMap, ITypeMapCollection dependencies = null) {
            container.Configure(x => {
                var use = x.For(typeMap.ServiceType)
                           .Use(typeMap.ConcreteType);

                if (typeMap.Name.IsNotNullOrEmpty()) {
                    use.Named(typeMap.Name);
                }

                if (dependencies.IsNotNullOrEmpty()) {
                    x.For(typeMap.ServiceType).Use("composite", BuildExpression(typeMap, dependencies));
                }
            });
        }

        private Func<IContext, object> BuildExpression(TypeMap typeMap, ITypeMapCollection dependencies) {
            var contextParameter = Expression.Parameter(typeof(IContext), "context");
            var @params = dependencies.ToArray(d => d.ServiceType);
            var ctorInfo = typeMap.ConcreteType.GetConstructor(@params);
            var genericMethodInfo = typeof(IContext).GetMethods().First(method => {
                return method.Name.Equals("GetInstance") &&
                        method.IsGenericMethodDefinition &&
                        method.GetParameters().Length == 1;
            });

            var getInstanceCallExpressions = dependencies.Select(dependency => {
                var nameParam = Expression.Constant(dependency.Name, typeof(string));
                var methodInfo = genericMethodInfo.MakeGenericMethod(new[] { dependency.ServiceType });

                return Expression.Call(contextParameter, methodInfo, new[] { nameParam });
            });

            var lambda = Expression.Lambda<Func<IContext, object>>(
                            Expression.New(ctorInfo, getInstanceCallExpressions),
                            contextParameter);

            return lambda.Compile();
        }
    }
}
