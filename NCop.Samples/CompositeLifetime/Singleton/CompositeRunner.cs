using NCop.Composite.Framework;
using NCop.Composite.Runtime;
using System;

namespace NCop.Samples.CompositeLifetime.Singleton
{
    public static class CompositeRunner
    {
        public static void Run() {
            IDeveloper developer = null;
            var container = new CompositeContainer(new CompositeRuntimeSettings {
                Types = new[] { typeof(IDeveloper) }
            });

            container.Configure();
            developer = container.Resolve<IDeveloper>();
            Console.WriteLine("All instances are the same: {0}", developer == container.Resolve<IDeveloper>());
        }
    }
}
