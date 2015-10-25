using NCop.Composite.Framework;
using NCop.Composite.Runtime;
using NCop.Samples.AtomMixin;
using System;

namespace NCop.Samples.PropertyInterceptionAppect
{
    public class CompositeRunner
    {
        public static void Run() {
            IDeveloper developer = null;
            var container = new CompositeContainer(new CompositeRuntimeSettings {
                Types = new[] { typeof(IDeveloper) }
            });

            container.Configure();
            developer = container.Resolve<IDeveloper>();
            developer.Code = "C# coding";
            Console.WriteLine(developer.Code);
        }
    }
}
