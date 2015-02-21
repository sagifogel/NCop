using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Composite.Mixins.Weaving;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.Mixins.Weaving;
using NCop.Weaving;
using System;
using System.Linq;

namespace NCop.Composite.Weaving
{
    internal class CompositeTypeWeaverBuilder : ITypeWeaverBuilder
    {
        private readonly ICompositeMixinsTypeWeaverBuilder builder = null;

        internal CompositeTypeWeaverBuilder(ICompositeWeavingSettings compositeWeavingSettings) {
            var registry = compositeWeavingSettings.Registry;
            var mixinsMap = compositeWeavingSettings.MixinsMap;
            var aspectsMap = compositeWeavingSettings.AspectsMap;
            var compositeType = compositeWeavingSettings.CompositeType;
            IAspectWeavingServices weavingServices = compositeWeavingSettings;
            var aspectMappedMembers = compositeWeavingSettings.AspectMemebrsCollection;
            var typeDefinitionWeaver = new MixinsTypeDefinitionWeaver(compositeType, mixinsMap);
            var compositeMappedMembers = new CompositeMemberMapper(aspectsMap, aspectMappedMembers);
            var typeDefinition = typeDefinitionWeaver.Weave();

            if (IsAtomComposite(compositeType, mixinsMap)) {
                builder = new AtomCompositeMixinsWeaverBuilder(compositeType, typeDefinition, registry);
            }
            else {
                builder = new CompositeMixinsWeaverBuilder(compositeType, typeDefinition, registry);
            }

            mixinsMap.ForEach(map => builder.Add(map));

            compositeMappedMembers.Methods.ForEach(compositeMethodMap => {
                var methodBuilder = new CompositeMethodWeaverBuilder(compositeMethodMap, typeDefinition, weavingServices);

                builder.Add(methodBuilder);
            });

            if (compositeMappedMembers.Properties.IsNotNullOrEmpty()) {
                var propertyMapVisitor = new CompositePropertyMapVisitor();

                compositeMappedMembers.Properties.ForEach(compositePropertyMap => {
                    var propertyBuilderFactory = compositePropertyMap.Accept(propertyMapVisitor);

                    builder.Add(propertyBuilderFactory.Get(typeDefinition, weavingServices));
                });
            }
        }

        public ITypeWeaver Build() {
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
