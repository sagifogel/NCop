using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCop.Core;
using NCop.Core.Mixin;
using NCop.Core.Weaving;
using NCop.Core.Extensions;
using System;
using NCop.Mixins.Engine;

namespace NCop.Mixins.Weaving
{
    public class MixinsWeaverStrategy : ITypeWeaver
    {
        private readonly IEnumerable<IMethodWeaver> _methodWeavers = null;
        private readonly ITypeDefinitionFactory _typeDefinitionFactory = null;

        public MixinsWeaverStrategy(ITypeDefinitionFactory typeDefinitionFactory, IEnumerable<IMethodWeaver> methodWeavers) {
            _methodWeavers =  methodWeavers;
            _typeDefinitionFactory = typeDefinitionFactory;
        }

        public void Weave() {
            var typeDefinition = _typeDefinitionFactory.Resolve();

            _methodWeavers.ForEach(methodWeaver => {
                var methodBuilder = methodWeaver.DefineMethod(typeDefinition);
                var ilGenerator = methodBuilder.GetILGenerator();

                methodWeaver.WeaveMethodScope(ilGenerator, typeDefinition);
                methodWeaver.WeaveEndMethod(ilGenerator);
            });
        }
    }
}
