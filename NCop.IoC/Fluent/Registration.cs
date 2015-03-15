using System;

namespace NCop.IoC.Fluent
{
    public class Registration : IReuseStrategyRegistration, IFactoryRegistration, IReusedWithin
    {
        public string Name { get; protected internal set; }

        public Type CastTo { get; protected internal set; }

        public Owner Owner { get; protected internal set; }

        public Delegate Func { get; protected internal set; }

        public Type FactoryType { get; protected internal set; }

        public Type ServiceType { get; protected internal set; }

        public ReuseScope Scope { get; protected internal set; }
        
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
