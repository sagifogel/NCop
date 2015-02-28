using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class TransientAspectAttribute : AspectLifetimeStrategyAttribute
    {
        public override LifetimeStrategy LifetimeStrategy {
            get {
                return LifetimeStrategy.Transient;
            }
        }
    }
}
