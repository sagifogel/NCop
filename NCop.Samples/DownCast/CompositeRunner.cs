using NCop.Composite.Framework;
using NCop.Composite.Runtime;

namespace NCop.Samples.DownCast
{
    public static class CompositeRunner
    {
        public static void Run() {
            IDeveloper developer = null;
            var container = new CompositeContainer(new CompositeRuntimeSettings {
                Types = new[] { typeof(ICSharpDeveloper) }
            });

            container.Configure();
            developer = container.Resolve<IDeveloper>();
            developer.Code();
        }
    }
}
