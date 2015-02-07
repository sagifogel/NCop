﻿using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Composite.Weaving
{
    public class CompositeMethodWeaverBuilder : AbstractWeaverBuilder<MethodInfo>, IMethodWeaverBuilder
    {
        private readonly ICompositeMethodMap compositeMethodMap = null;
        private readonly IAspectWeavingServices aspectWeavingServices = null;

        public CompositeMethodWeaverBuilder(ICompositeMethodMap compositeMethodMap, ITypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(compositeMethodMap.ContractType, typeDefinition) {
            this.compositeMethodMap = compositeMethodMap;
            this.aspectWeavingServices = aspectWeavingServices;
        }

        public IMethodWeaver Build() {
            var weavingSettings = new WeavingSettingsImpl(contractType, typeDefinition);

            if (compositeMethodMap.HasAspectDefinitions) {
                var aspectWeavingSettings = new AspectWeavingSettingsImpl {
                    WeavingSettings = weavingSettings,
                    AspectRepository = aspectWeavingServices.AspectRepository,
                    AspectArgsMapper = aspectWeavingServices.AspectArgsMapper
                };

                return new CompositeMethodWeaver(compositeMethodMap.Target, compositeMethodMap.AspectDefinitions, aspectWeavingSettings);
            }

            return new MethodDecoratorWeaver(compositeMethodMap.ContractMember, weavingSettings);
        }
    }
}
