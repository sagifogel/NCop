
namespace NCop.IoC
{
    public class ServiceEntry
    {
        public Owner Owner { get; set; }
        public object Factory { get; set; }
        public Lifetime Lifetime { get; set; }
        public INCopDependencyContainer Container { get; set; }
        public ILifetimeStrategy LifetimeStrategy { get; set; }

        internal ServiceEntry CloneFor(INCopDependencyContainer container) {
            return new ServiceEntry {
                Owner = Owner,
                Factory = Factory,
                Lifetime = Lifetime,
                Container = container,
                LifetimeStrategy = Lifetime.ToStrategy(container)
            };
        }
    }
}
