using NCop.Composite.Engine;
using NCop.Composite.Weaving;
using NCop.Core;
using System.Linq;
using NCop.Core.Extensions;
using NCop.Core.Runtime;
using NCop.IoC;
using System;
using NCop.IoC.Fluent;
using System.Reflection;
using NCop.Composite.Exceptions;
using NCop.Weaving;

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
                               .Select(type => new {
                                   Type = type,
                                   Attributes = type.GetCustomAttributesArray<CompositeAttribute>()
                               })
                               .Where(composite => composite.Attributes.Length > 0);
            });

            var bulkWeaving = new BulkWeaving(composites.Select(composite => {
                CompositeTypeWeaverBuilder builder = null;

                if (composite.Attributes.Length > 1) {
                    throw new DuplicateCompositeAnnotationException(composite.Type);
                }

                builder = new CompositeTypeWeaverBuilder(composite.Type, registry);

                return builder.Build();
            }));

            bulkWeaving.Weave();
        }
    }
}

