using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCop.Core;
using NCop.Weaving;
using NCop.Core.Extensions;
using System;
using NCop.Mixins.Engine;
using NCop.IoC;

namespace NCop.Composite.Weaving
{
    internal class AtomMixinsWeaverStartegy : ITypeWeaver
    {
        private readonly TypeMap mixin = null;
        private readonly ITypeDefinition typeDefinition = null;
        private readonly INCopDependencyAwareRegistry registry = null;
        private readonly IEnumerable<IMethodWeaver> methodWeavers = null;

        internal AtomMixinsWeaverStartegy(ITypeDefinition typeDefinition, TypeMap mixin, IEnumerable<IMethodWeaver> methodWeavers, INCopDependencyAwareRegistry registry) {
            this.mixin = mixin;
            this.registry = registry;
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
            registry.Register(weavedType, typeDefinition.Type, new TypeMapSet { mixin });
        }
    }
}
