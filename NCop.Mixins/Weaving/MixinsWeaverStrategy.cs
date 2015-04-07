using NCop.Core;
using NCop.Core.Extensions;
using NCop.IoC;
using NCop.Weaving;
using System;
using System.Collections.Generic;

namespace NCop.Mixins.Weaving
{
    public class MixinsWeaverStrategy : ITypeWeaver
    {
        private readonly ITypeMap mixinsMap = null;
        private readonly ITypeDefinition typeDefinition = null;
        private readonly INCopDependencyAwareRegistry registry = null;
        private readonly IEnumerable<IMethodWeaver> methodWeavers = null;

        public MixinsWeaverStrategy(ITypeDefinition typeDefinition, ITypeMap mixinsMap, IEnumerable<IMethodWeaver> methodWeavers, INCopDependencyAwareRegistry registry) {
            this.registry = registry;
            this.mixinsMap = mixinsMap;
            this.methodWeavers = methodWeavers;
            this.typeDefinition = typeDefinition;
        }

        public void Weave() {
            Type weavedType = null;

            methodWeavers.ForEach(methodWeaver => {
                var methodBuilder = methodWeaver.DefineMethod();
                var ilGenerator = methodBuilder.GetILGenerator();

                methodWeaver.WeaveMethodScope(ilGenerator);
                methodWeaver.WeaveEndMethod(ilGenerator);
            });

            weavedType = typeDefinition.TypeBuilder.CreateType();
            registry.Register(weavedType, typeDefinition.Type, mixinsMap);
        }
    }
}
