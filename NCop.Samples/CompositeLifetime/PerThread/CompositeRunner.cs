using NCop.Composite.Framework;
using NCop.Composite.Runtime;
using System;
using System.Threading.Tasks;

namespace NCop.Samples.CompositeLifetime.PerThread
{
    public static class CompositeRunner
    {
        public async static Task Run() {
            IDeveloper developer = null;
            bool sameInstanceAtEachThread = false;
            IDeveloper otherThreadDeveloper = null;
            var container = new CompositeContainer(new CompositeRuntimeSettings {
                Types = new[] { typeof(IDeveloper) }
            });

            container.Configure();
            otherThreadDeveloper = await Task.Factory.StartNew<IDeveloper>(() => {
                var first = container.Resolve<IDeveloper>();

                sameInstanceAtEachThread = container.Resolve<IDeveloper>() == first;

                return first;
            });

            developer = container.Resolve<IDeveloper>();
            Console.WriteLine("Instance is created for each thread: {0}", otherThreadDeveloper != container.Resolve<IDeveloper>());
            Console.WriteLine("All instances in the same thread are the same: {0}", sameInstanceAtEachThread && developer == container.Resolve<IDeveloper>());
        }
    }
}
