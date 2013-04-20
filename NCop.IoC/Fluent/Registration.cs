using NCop.IoC.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NCop.Core.Extensions;
using System.Runtime.CompilerServices;

namespace NCop.IoC.Fluent
{
    public class Registration : ILiftimeStrategyRegistration, IFactoryRegistration, IRegistration
    {   
        public string Name { get; internal set; }

        public Type CastTo { get; internal set; }

        public Delegate Func { get; internal set; }

        public Type FactoryType { get; internal set; }

        public Type ServiceType { get; internal set; }

        public INCopContainer Container { get; internal set; }

        public ILifetimeStrategy ToSelf() {
            throw new NotImplementedException();
        }

        public void AsSingleton() {
            var container = Expression.Parameter(typeof(INCopContainer), "container");
            var @params = Func.Method
                              .GetParameters()
                              .Where(p => !p.ParameterType.Equals(typeof(Closure)))
                              .Select(p => p.ParameterType)
                              .Concat(Func.Method.ReturnType)
                              .ToArray();

            var invocation = Expression.Lambda(Expression.Invoke(Expression.Constant(Func), container), container);
            var compiled = invocation.Compile();
            var instance = compiled.DynamicInvoke(Container);
            var lambda = Expression.Lambda(
                            Expression.GetFuncType(@params),
                            Expression.Constant(instance), 
                            container);

            Func = lambda.Compile();
        }

        public void Named(string name) {
            Name = name;
        }

        ILifetimeStrategy IDescriptable.Named(string name) {
            Named(name);

            return this;
        }
    }
}
