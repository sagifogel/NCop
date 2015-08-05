using NCop.Composite.Framework;

namespace NCop.Aspects.Tests
{
    public enum AspectJoinPoints
    {
        OnAdd,
        OnExit = 1,
        OnEntry,
        OnInvoke,
        OnRemove,
        InMethod,
        OnSuccess,
        OnException,
        GetPropertyInterception,
        SetPropertyInterception
    }

    public abstract class AbstractAspectTest
    {
        protected static CompositeContainer container = null;

        static AbstractAspectTest() {
            container = new CompositeContainer();
            container.Configure();
        }
    }
}
