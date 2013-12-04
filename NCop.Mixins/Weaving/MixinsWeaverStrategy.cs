using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCop.Core;
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
        private readonly ITypeDefinition typeDefinition = null;

        internal MixinsWeaverStrategy(ITypeDefinition typeDefinition, IEnumerable<IMethodWeaver> methodWeavers, IRegistry registry) {
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
            registry.Register(weavedType, typeDefinition.Type);
        }
    }
}
