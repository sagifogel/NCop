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

        public Lifetime Lifetime { get; protected internal set; }

        public IReusedWithin AsSingleton() {
            Lifetime = Lifetime.Container;
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

        public IOwnedBy WithinHierarchy() {
            Lifetime = Lifetime.Hierarchy;

            return this;
        }

        public IOwnedBy WithinContainer() {
            Lifetime = Lifetime.Container;

            return this;
        }

        public void OwnedByContainer() {
            Owner = Owner.Container;
        }

        public void OwnedExternally() {
            Owner = Owner.External;
        }

        public IOwnedBy PerThread() {
            Lifetime = Lifetime.Request;

            return this;
        }

        public IOwnedBy PerHttpRequest() {
            Lifetime = Lifetime.Request;

            return this;
        }
    }
}
