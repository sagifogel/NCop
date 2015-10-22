using NCop.Composite.Framework;
using NCop.Samples.AtomMixin;

namespace NCop.Samples.SearchCompositesInAllAssemblies
{
    public class CompositeRunner
    {
        public static void Run() {
            IDeveloper developer = null;
            var container = new CompositeContainer();

            container.Configure();
            developer = container.Resolve<IDeveloper>();
            developer.Code();
        }
    }
}
