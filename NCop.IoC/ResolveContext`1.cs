using System;

namespace NCop.IoC
{
    public class ResolveContext<TService>
    {
        internal ServiceKey Key { get; set; }
        internal ServiceEntry Entry { get; set; }
        internal Func<TService> Factory { get; set; }
        internal INCopDependencyResolver Container { get; set; }
        internal Action<ServiceKey, ServiceEntry> Registry { get; set; }
    }
}
