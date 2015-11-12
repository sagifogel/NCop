using NCop.Composite.Framework;
using NCop.Composite.Runtime;
using NCop.Samples.IntegrationWithExternalIoC;
using StructureMap;

namespace NCop.Samples.DependableMixins
{
    public static class CompositeRunner
    {
        public static void Run() {
            IPerson person = null;
            var smContainer = ObjectFactory.Container;
            var container = new CompositeContainer(new CompositeRuntimeSettings {
                Types = new[] { typeof(IPerson) },
                DependencyContainerAdapter = new StructureMapAdapter(smContainer)
            });

            smContainer.Configure(x => {
                x.For<ICSharpLanguageVersion>().Use<CSharp5LanguageVersion>();
            });

            container.Configure();
            person = container.Resolve<IPerson>();
            person.Code();
        }
    }
}
