using NCop.Composite.Framework;
using NCop.Composite.Runtime;
using NCop.Samples.IntegrationWithExternalIoC;
using StructureMap;

namespace NCop.Samples.DependableMixins
{
    public static class CompositeRunner
    {
        public static void Run() {
            IDeveloper developer = null;
            var smContainer = ObjectFactory.Container;
            var container = new CompositeContainer(new CompositeRuntimeSettings {
                Types = new[] { typeof(IDeveloper) },
                DependencyContainerAdapter = new StructureMapAdapter(smContainer)
            });

            smContainer.Configure(x => {
                x.For<IDeveloper>().Use<CSharpDeveloperMixin>();
                x.For<ICSharpLanguageVersion>().Use<CSharp5LanguageVersion>();
            });

            container.Configure();
            developer = container.Resolve<IDeveloper>();
            developer.Code();
        }
    }
}
