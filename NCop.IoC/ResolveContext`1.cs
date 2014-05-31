using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public class ResolveContext<TService>
    {
        public ServiceKey Key { get; set; }
        public ServiceEntry Entry { get; set; }
        public Func<TService> Factory { get; set; }
        public INCopDependencyResolver Container { get; set; }
        public Action<ServiceKey, ServiceEntry> Registry { get; set; }
    }
}
