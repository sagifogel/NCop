using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Composite.Weaving
{
    public class CompositePropertyWeaverBuilder : AbstractWeaverBuilder<PropertyInfo>, IPropertyWeaverBuilder
    {
        private readonly PropertyInfo memberInfoContract = null;
        private readonly ICompositePropertyMap compositePropertyMap = null;
        private readonly IAspectWeavingServices aspectWeavingServices = null;

        public CompositePropertyWeaverBuilder(ICompositePropertyMap compositePropertyMap, ITypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(compositePropertyMap.ImplementationMember, compositePropertyMap.ImplementationType, compositePropertyMap.ContractType, typeDefinition) {
            this.compositePropertyMap = compositePropertyMap;
            this.aspectWeavingServices = aspectWeavingServices;
            memberInfoContract = compositePropertyMap.ContractMember;
        }

        public IPropertyWeaver Build() {
            var weavingSettings = new PropertyWeavingSettings(memberInfoImpl, memberInfoContract, implementationType, contractType, typeDefinition);

            if (compositePropertyMap.HasAspectDefinitions) {
                var aspectWeavingSettings = new CompositePropertyWeavingSettings {
                    WeavingSettings = weavingSettings,
                    AspectRepository = aspectWeavingServices.AspectRepository,
                    AspectArgsMapper = aspectWeavingServices.AspectArgsMapper
                };

                return new CompositePropertyWeaver(compositePropertyMap.AspectDefinitions, aspectWeavingSettings);
            }

            return new PropertyDecoratorWeaver(weavingSettings);
        }
    }
}
