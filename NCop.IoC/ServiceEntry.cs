
namespace NCop.IoC
{
    public class ServiceEntry
    {
        internal Owner Owner { get; set; }
        internal object Factory { get; set; }
        internal ReuseScope Scope { get; set; }
        internal INCopDependencyResolver Container { get; set; }
        internal ILifetimeStrategy LifetimeStrategy { get; set; }

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
