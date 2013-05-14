using NCop.Composite.Engine;
using NCop.Composite.Weaving;
using NCop.Core;
using System.Linq;
using NCop.Core.Extensions;
using NCop.Core.Runtime;
using NCop.IoC;
using System;
using NCop.IoC.Fluent;

namespace NCop.Composite.Framework
{
    internal class CompositeRuntime : IRuntime
    {
        private readonly IRegistry registry = null;
        private readonly RuntimeSettings settings = null;

        public CompositeRuntime(RuntimeSettings settings, IRegistry registry) {
            this.registry = registry; 
            this.settings = settings ?? new RuntimeSettings();
        }

        public void Run() {
            var composites = settings.Assemblies.SelectMany(assembly => {
                return assembly.GetTypes()
                               .Where(type => type.IsNCopDefined<CompositeAttribute>());
            });

            var weavers = composites.Select(composite => {
                var builder = new CompositeTypeWeaverBuilder(composite, registry);

                return builder.Build();
            });

            foreach (var weaver in weavers) {
                weaver.Weave();
            }
        }
    }
}

