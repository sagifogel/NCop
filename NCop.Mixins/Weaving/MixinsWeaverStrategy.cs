using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCop.Core;
using NCop.Core.Mixin;
using NCop.Weaving;
using NCop.Core.Extensions;
using System;
using NCop.Mixins.Engine;

namespace NCop.Mixins.Weaving
{
    internal class MixinsWeaverStrategy : ITypeWeaver
    {
        private readonly IEnumerable<IMethodWeaver> methodWeavers = null;
        private readonly ITypeDefinitionFactory typeDefinitionFactory = null;

        internal MixinsWeaverStrategy(ITypeDefinitionFactory typeDefinitionFactory, IEnumerable<IMethodWeaver> methodWeavers) {
            this.methodWeavers =  methodWeavers;
            this.typeDefinitionFactory = typeDefinitionFactory;
        }

        public void Weave() {
            var typeDefinition = typeDefinitionFactory.Resolve();

            methodWeavers.ForEach(methodWeaver => {
                var methodBuilder = methodWeaver.DefineMethod(typeDefinition);
                var ilGenerator = methodBuilder.GetILGenerator();

                methodWeaver.WeaveMethodScope(ilGenerator, typeDefinition);
                methodWeaver.WeaveEndMethod(ilGenerator);
            });
        }
    }
}
