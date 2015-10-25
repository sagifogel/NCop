using NCop.Composite.Framework;
using NCop.Composite.Runtime;
using NCop.Samples.AtomMixin;

namespace NCop.Samples.IntegrationWithExternalIoC
{
    public static class CompositeRunner
    {
        public static void Run() {
            IDeveloper developer = null;
            var container = new CompositeContainer(new CompositeRuntimeSettings {
                Types = new[] { typeof(IDeveloper) },
                DependencyContainerAdapter = new StructureMapAdapter()
            });

            container.Configure();
            developer = container.Resolve<IDeveloper>();
            developer.Code();
        }
    }
}
