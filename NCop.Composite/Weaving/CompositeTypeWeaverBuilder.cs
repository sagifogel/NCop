using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.Weaving;
using System;
using System.Linq;

namespace NCop.Composite.Weaving
{
    internal class CompositeTypeWeaverBuilder : ITypeWeaverBuilder
    {
        private readonly ICompositeWeavingSettings compositeWeavingSettings = null;

        internal CompositeTypeWeaverBuilder(ICompositeWeavingSettings compositeWeavingSettings) {
            this.compositeWeavingSettings = compositeWeavingSettings;
        }

        public ITypeWeaver Build() {
            ICompositeMixinsTypeWeaverBuilder builder = null;
            var registry = compositeWeavingSettings.Registry;
            var mixinsMap = compositeWeavingSettings.MixinsMap;
            var aspectsMap = compositeWeavingSettings.AspectsMap;
            var compositeType = compositeWeavingSettings.CompositeType;
            var aspectMappedMembers = compositeWeavingSettings.AspectMemebrsCollection;
            var compositeMappedMembers = new CompositeMemberMapper(aspectsMap, aspectMappedMembers);
            var typeDefinitionWeaver = new CompositeTypeDefinitionWeaver(compositeType, mixinsMap, compositeMappedMembers);
            var typeDefinition = typeDefinitionWeaver.Weave() as IAspectTypeDefinition;
            
            if (IsAtomComposite(compositeType, mixinsMap)) {
                builder = new AtomCompositeMixinsWeaverBuilder(compositeType, typeDefinition, registry);
            }
            else {
                builder = new CompositeMixinsWeaverBuilder(compositeType, typeDefinition, registry);
            }

            mixinsMap.ForEach(map => builder.Add(map));

            compositeMappedMembers.Events.ForEach(compositeEventMap => {
                var eventBuilder = new CompositeEventWeaverBuilder(compositeEventMap, typeDefinition, compositeWeavingSettings);

                builder.Add(eventBuilder);
            });

            compositeMappedMembers.Methods.ForEach(compositeMethodMap => {
                var methodBuilder = new CompositeMethodWeaverBuilder(compositeMethodMap, typeDefinition, compositeWeavingSettings);

                builder.Add(methodBuilder);
            });

            compositeMappedMembers.Properties.ForEach(compositePropertyMap => {
                var propertyBuilder = new CompositePropertyWeaverBuilder(compositePropertyMap, typeDefinition, compositeWeavingSettings);

                builder.Add(propertyBuilder);
            });

            return builder.Build();
        }

        private bool IsAtomComposite(Type compositeType, ITypeMap mixinsMap) {
            if (mixinsMap.Count == 1) {
                var mixinMap = mixinsMap.First();

                return ReferenceEquals(mixinMap.ContractType, compositeType);
            }

            return false;
        }
    }
}
