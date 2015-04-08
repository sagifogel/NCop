using NCop.Core.Extensions;
using NCop.IoC;
using NCop.IoC.Fluent;
using System;

namespace NCop.Composite.IoC
{
    internal class CompositeContainer : NCopContainer, IRegistrationResolver
    {
        protected override IContainerRegistry CreateRegistry() {
            return new CompositeContainerRegistry();
        }

        protected override ServiceEntry CreateServiceEntry(IRegistration registration) {
            if (registration.Is<CompositeTypeRegistration>()) {
                return new CompositeServiceEntry {
                    Container = this,
                    Owner = registration.Owner,
                    Scope = registration.Scope,
                    Factory = registration.Func,
                    LifetimeStrategy = registration.Scope.ToStrategy(this)
                };
            }

            return base.CreateServiceEntry(registration);
        }

        protected override void RegisterAsDisposableIfNeeded<TService>(ServiceEntry entry, TService instance) {
            if (entry is CompositeServiceEntry) {
                base.RegisterAsDisposableIfNeeded(entry, instance);
            }
        }

        public IRegistration Resolve(Type concreteType) {
            return ((CompositeContainerRegistry)registry).Resolve(concreteType);
        }
    }
}
