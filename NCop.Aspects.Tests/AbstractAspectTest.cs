using NCop.Composite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Tests
{
    public enum AspectJoinPoints
    {
        OnExit = 1,
        OnEntry,
        OnInvoke,
        InMethod,
        OnSuccess,
        OnException
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
