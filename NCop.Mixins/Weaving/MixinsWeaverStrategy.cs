using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCop.Core;
using NCop.Core.Mixin;
using NCop.Weaving;
using NCop.Core.Extensions;
using System;
using NCop.Mixins.Engine;
using NCop.IoC;

namespace NCop.Mixins.Weaving
{
    internal class MixinsWeaverStrategy : ITypeWeaver
    {
        private readonly IRegistry registry = null;
        private readonly IEnumerable<IMethodWeaver> methodWeavers = null;
        private readonly ITypeDefinitionFactory typeDefinitionFactory = null;

        internal MixinsWeaverStrategy(ITypeDefinitionFactory typeDefinitionFactory, IEnumerable<IMethodWeaver> methodWeavers, IRegistry registry) {
            this.registry = registry;
            this.methodWeavers = methodWeavers;
            this.typeDefinitionFactory = typeDefinitionFactory;
        }

        public void Weave() {
            Type weavedType = null;
            var typeDefinition = typeDefinitionFactory.Resolve();

            methodWeavers.ForEach(methodWeaver => {
                var methodBuilder = methodWeaver.DefineMethod(typeDefinition);
                var ilGenerator = methodBuilder.GetILGenerator();

                methodWeaver.WeaveMethodScope(ilGenerator, typeDefinition);
                methodWeaver.WeaveEndMethod(ilGenerator);
            });

            weavedType = typeDefinition.TypeBuilder.CreateType();
            registry.Register(weavedType, typeDefinition.Type);
        }
    }
}
