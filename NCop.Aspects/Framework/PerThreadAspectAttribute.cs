using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class PerThreadAspectAttribute : AspectLifetimeStrategyAttribute
    {
        public override LifetimeStrategy LifetimeStrategy {
            get {
                return LifetimeStrategy.PerThread;
            }
        }
    }
}
