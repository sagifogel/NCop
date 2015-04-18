using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Composite.Weaving;
using NCop.Core.Extensions;
using NCop.Core.Runtime;
using NCop.IoC;
using NCop.Mixins.Engine;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NCop.Composite.Framework
{
    internal class CompositeRuntime : IRuntime
    {
        private readonly IRuntimeSettings settings = null;
        private readonly INCopDependencyAwareRegistry registry = null;

        public CompositeRuntime(IRuntimeSettings settings, INCopDependencyAwareRegistry registry) {
            this.registry = registry;
            this.settings = settings ?? new RuntimeSettings();
        }

        public void Run() {
            ITypeWeaver bulkWeaving = null;
            var compositesQueue = new Queue<ITypeWeaver>();
            AspectsAttributeWeaver aspectRepository = null;
            AspectArgsMapperWeaver aspectArgsMapperWeaver = null;
            var aspectDefinitionsTypeSet = new HashSet<Type>();

            var composites = settings.Assemblies.SelectMany(assembly => {
                return assembly.GetTypes()
                               .Select(type => new {
                                   Type = type,
                                   Attributes = type.GetCustomAttributesArray<CompositeAttribute>()
                               })
                               .Where(composite => composite.Attributes.Length > 0);
            });

            var compositeWeavingSettings = composites.ToList(composite => {
                var compositeType = composite.Type;
                var mixinsMap = new MixinsMap(compositeType);
                var aspectMappedMembers = new AspectMemberMapper(compositeType, mixinsMap);
                var aspectsMap = new AspectsMap(aspectMappedMembers);

                var aspectDefinitionsTypes = aspectsMap.SelectMany(aspectMap => {
                    return aspectMap.Aspects.Select(aspectDefinition => {
                        return aspectDefinition.Aspect.AspectType;
                    });
                });

                aspectDefinitionsTypeSet.AddRange(aspectDefinitionsTypes);

                return new CompositeWeavingSettingsImpl {
                    Registry = registry,
                    MixinsMap = mixinsMap,
                    AspectsMap = aspectsMap,
                    CompositeType = compositeType,
                    AspectMemebrsCollection = aspectMappedMembers
                };
            });

            aspectArgsMapperWeaver = new AspectArgsMapperWeaver();
            aspectRepository = new AspectsAttributeWeaver(aspectDefinitionsTypeSet);
            compositesQueue.Enqueue(aspectArgsMapperWeaver);
            compositesQueue.Enqueue(aspectRepository);

            compositeWeavingSettings.ForEach(compositeSettings => {
                IBuilder<ITypeWeaver> builder = null;

                compositeSettings.AspectRepository = aspectRepository;
                compositeSettings.AspectArgsMapper = aspectArgsMapperWeaver;
                builder = new CompositeTypeWeaverBuilder(compositeSettings);

                compositesQueue.Enqueue(builder.Build());
            });

            bulkWeaving = new BulkWeaving(compositesQueue);
            bulkWeaving.Weave();
        }
    }
}

