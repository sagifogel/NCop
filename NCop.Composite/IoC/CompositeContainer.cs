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

        public IRegistration Resolve(Type concreteType) {
            return ((CompositeContainerRegistry)registry).Resolve(concreteType);
        }
    }
}
