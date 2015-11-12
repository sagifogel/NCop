using NCop.Composite.Framework;
using NCop.Composite.Runtime;
using System;

namespace NCop.Samples.EventInterceptionAspect.EventFunctionInterceptionAspect
{
    public static class CompositeRunner
    {
        public static void Run() {
            IDeveloper developer = null;
            Func<string> handler = () => "C# coding";
            var container = new CompositeContainer(new CompositeRuntimeSettings {
                Types = new[] { typeof(IDeveloper) }
            });

            container.Configure();
            developer = container.Resolve<IDeveloper>();
            developer.OnCodeCompleted += handler;
            developer.Code();
            developer.OnCodeCompleted -= handler;
        }
    }
}
