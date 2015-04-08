using NCop.Composite.Properties;
using NCop.Core;
using NCop.IoC;
using NCop.IoC.Fluent;
using System;
using System.Collections.Generic;

namespace NCop.Composite.IoC
{
    internal class CompositeContainerRegistry : AbstractContainerRegistry, IRegistrationResolver
    {
        protected readonly Dictionary<Type, IRegistration> registrations = null;

        internal CompositeContainerRegistry() {
            registrations = new Dictionary<Type, IRegistration>();
        }

        private IEnumerable<IRegistration> Registrations {
            get {
                return registrations.Values;
            }
        }
        public override IEnumerator<IRegistration> GetEnumerator() {
            return Registrations.GetEnumerator();
        }

        public override void Register(IRegistration registration) {
            var concreteType = registration.Func.Method.ReturnType;

            registrations.Add(concreteType, registration);
        }

        public override void Register(Type concreteType, Type serviceType, ITypeMap dependencies = null, string name = null, bool isComposite = false) {
            RegisterImpl(new ReflectionRegistration(concreteType, serviceType));
        }

        public IRegistration Resolve(Type concreteType) {
            IRegistration registration;

            if (!TryResolve(concreteType, out registration)) {
                throw new RegistrationException(Resources.CouldNotResolveType);
            }

            return registration;
        }

        public bool TryResolve(Type concreteType, out IRegistration registration) {
            return registrations.TryGetValue(concreteType, out registration);
        }
    }
}
