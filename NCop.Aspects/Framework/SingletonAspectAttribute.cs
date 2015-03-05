using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class SingletonAspectAttribute : AspectLifetimeStrategyAttribute
    {
        public override LifetimeStrategy LifetimeStrategy {
            get {
                return LifetimeStrategy.Singleton;
            }
        }
    }
}
