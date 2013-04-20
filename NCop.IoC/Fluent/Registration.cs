using NCop.IoC.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NCop.Core.Extensions;

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
                              .Skip(1)
                              .Select(p => p.ParameterType)
                              .Concat(Func.Method.ReturnType)
                              .ToArray();

            var variable = Expression.Variable(Func.Method.ReturnType);
            var freeVariable = Expression.Assign(variable, Expression.Invoke(Expression.Constant(Func), container));
            var returnFreeVariable = Expression.Lambda(Expression.GetFuncType(variable.Type), Expression.Constant(freeVariable));
            var funcType = Expression.GetFuncType(@params);
            var lambda = Expression.Lambda(funcType,
                                           Expression.Block(new[] { variable }, freeVariable, Expression.Invoke(returnFreeVariable)), 
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
