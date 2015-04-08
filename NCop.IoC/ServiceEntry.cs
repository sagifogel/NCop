
namespace NCop.IoC
{
    public class ServiceEntry
    {
        public Owner Owner { get; set; }
        public object Factory { get; set; }
        public ReuseScope Scope { get; set; }
        public INCopDependencyResolver Container { get; set; }
        public ILifetimeStrategy LifetimeStrategy { get; set; }

        internal ServiceEntry CloneFor(INCopDependencyResolver container) {
            return new ServiceEntry {
                Scope = Scope,
                Owner = Owner,
                Factory = Factory,
                Container = container,
                LifetimeStrategy = Scope.ToStrategy(container)
            };
        }
    }
}
