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
    public class Registration : IReuseStrategyRegistration, IFactoryRegistration, IRegistration, IReusedWithin
    {
        public string Name { get; internal set; }

        public Type CastTo { get; internal set; }

        public Owner Owner { get; internal set; }

        public Delegate Func { get; internal set; }

        public Type FactoryType { get; internal set; }

        public Type ServiceType { get; internal set; }

        public ReuseScope Scope { get; internal set; }
        
        public INCopContainer Container { get; internal set; }

        public IReusedWithin AsSingleton() {
            Scope = ReuseScope.Hierarchy;
            return this;
        }

        public IOwnedBy Named(string name) {
            Name = name;

            return this;
        }

        IReuseStrategy IDescriptable.Named(string name) {
            Named(name);

            return this;
        }

        public IOwnedBy ReusedWithinHierarchy() {
            Scope = ReuseScope.Hierarchy;
            
            return this;
        }

        public IOwnedBy ReusedWithinContainer() {
            Scope = ReuseScope.Container;
            
            return this;
        }

        public void OwnedByContainer() {
            Owner = Owner.Container;
        }

        public void OwnedExternally() {
            Owner = Owner.External;
        }
    }
}
