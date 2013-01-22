using NCop.Composite.Engine;
using NCop.Composite.Weaving;
using NCop.Core;
using System.Linq;
using NCop.Core.Extensions;

namespace NCop.Composite.Runtime
{
    public class CompositeRuntime : IRuntime
    {
        public RuntimeSettings Settings { get; set; }

        public void Run() {
            var settings = Settings ?? new RuntimeSettings();
            var composites = settings.Assemblies.SelectMany(assembly => {
                return assembly.GetTypes()
                               .Where(type => type.IsNCopDefined<CompositeAttribute>());
            });

            var weavers = composites.Select(composite => {
                var builder = new CompositeTypeWeaverBuilderVisitor(composite).Visit();
                
                return builder.Build();
            });

            foreach (var weaver in weavers) {
                weaver.Weave();
            }
        }
    }
}

