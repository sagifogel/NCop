using NCop.Composite.Framework;
using NCop.Composite.Runtime;

namespace NCop.Samples.DownCastAndNamedComposites
{
    public static class CompositeRunner
    {
        public static void Run() {
            IDeveloper developer = null;
            var container = new CompositeContainer(new CompositeRuntimeSettings {
                Types = new[] { typeof(ICSharpDeveloper), typeof(IJavaScriptDeveloper) }
            });

            container.Configure();
            developer = container.ResolveNamed<IDeveloper>("C#");
            developer.Code();
            developer = container.ResolveNamed<IDeveloper>("JavaScript");
            developer.Code();
        }
    }
}
