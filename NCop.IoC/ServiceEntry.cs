using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    internal class ServiceEntry
    {
        internal Owner Owner { get; set; }
        internal object Factory { get; set; }
        internal ReuseScope Scope { get; set; }
        internal NCopContainer Container { get; set; }
        internal ILifetimeStrategy LifetimeStrategy { get; set; }

        internal ServiceEntry CloneFor(NCopContainer container) {
            return new ServiceEntry {
                Scope = Scope,
                Owner = this.Owner,
                Container = container,
                Factory = this.Factory,
                LifetimeStrategy = Scope.ToStrategy(container)
            };
        }
    }
}
