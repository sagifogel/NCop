using NCop.IoC.Fluent;
using NCop.IoC.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;
using System.Collections.Concurrent;
using System.Collections;
using NCop.Core;

namespace NCop.IoC
{
    public class ContainerRegistry : AbstractContainerRegistry
    {
        protected readonly List<IRegistration> registrations = null;

        public ContainerRegistry() {
            registrations = new List<IRegistration>();
        }

        private IEnumerable<IRegistration> Registrations {
            get {
                return registrations;
            }
        }

        public override void Register(Type concreteType, Type serviceType, ITypeMap dependencies = null, string name = null) {
            RegisterImpl(new ReflectionRegistration(concreteType, serviceType));
        }

        public override IEnumerator<IRegistration> GetEnumerator() {
            return Registrations.GetEnumerator();
        }

        public override void Register(IRegistration registration) {
            registrations.Add(registration);
        }
    }
}
