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
    public class Registration : IReuseStrategyRegistration, IFactoryRegistration, IRegistration
    {   
        public string Name { get; internal set; }

        public Type CastTo { get; internal set; }

        public Delegate Func { get; internal set; }

        public Type FactoryType { get; internal set; }

        public Type ServiceType { get; internal set; }

        public ReuseScope Scope { get; internal set; }

        public INCopContainer Container { get; internal set; }

        public void AsSingleton() {
            Scope = ReuseScope.Container;
        }

        public void Named(string name) {
            Name = name;
        }

        IReuseStrategy IDescriptable.Named(string name) {
            Named(name);

            return this;
        }
    }
}
