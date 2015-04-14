using NCop.IoC;
using NCop.IoC.Fluent;
using System;

namespace NCop.Composite.IoC
{
    internal class CompositeRegistration : IReuseStrategyRegistration, IFactoryRegistration, IReusedWithin
    {
        public string Name { get; internal set; }

        public Type CastTo { get; internal set; }

        public Owner Owner { get; internal set; }

        public Delegate Func { get; internal set; }

        public Type FactoryType { get; internal set; }

        public Type ServiceType { get; internal set; }

        public Lifetime Lifetime { get; internal set; }

        public IReusedWithin AsSingleton() {
            Lifetime = Lifetime.Hierarchy;
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
            Lifetime = Lifetime.PerThread;

            return this;
        }

        public IOwnedBy PerHttpRequest() {
            Lifetime = Lifetime.HttpRequest;

            return this;
        }

        public IOwnedBy PerHybridRequest() {
            Lifetime = Lifetime.HybridRequest;

            return this;
        }
    }
}
