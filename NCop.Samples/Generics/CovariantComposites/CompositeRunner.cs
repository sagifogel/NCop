using NCop.Composite.Framework;
using NCop.Composite.Runtime;
using System;

namespace NCop.Samples.Generics.CovariantComposites
{
    public static class CompositeRunner
    {
        public static void Run() {
            ICSharpDeveloper developer = null;
            var container = new CompositeContainer(new CompositeRuntimeSettings {
                Types = new[] { typeof(ICSharpDeveloper) }
            });

            container.Configure();
            developer = container.Resolve<ICSharpDeveloper>();
            Console.WriteLine(developer.Code());
        }
    }
}
