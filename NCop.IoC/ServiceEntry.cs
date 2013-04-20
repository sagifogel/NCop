using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    internal class ServiceEntry
    {
        public ServiceEntry(Delegate factory, ILifetimeStrategy lifetimeStrategy) {
            Factory = factory;
            LifetimeStrategy = lifetimeStrategy;
        }

        public object Factory { get; set; }
        public object Instance { get; set; }
        public ILifetimeStrategy LifetimeStrategy { get; set; }
    }
}
