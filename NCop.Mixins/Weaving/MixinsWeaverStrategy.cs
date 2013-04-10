using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCop.Core;
using NCop.Core.Mixin;
using NCop.Core.Weaving;
using NCop.Core.Extensions;
using NCop.Core.Weaving.Proxies;
using System;
using NCop.Mixins.Engine;

namespace NCop.Mixins.Weaving
{
    public class MixinsWeaverStrategy : ITypeWeaver
    {
        private readonly Type _mixinsType = null;
        private readonly IMixinsMap _mixinsMap = null;
        private readonly IEnumerable<IMethodWeaver> _methodWeavers = null;

        public MixinsWeaverStrategy(Type mixinsType, IMixinsMap mixinsMap, IEnumerable<IMethodWeaver> methodWeavers) {
            _mixinsType = mixinsType;
            _methodWeavers = methodWeavers;
        }

        public void Weave() {
            var mixinsTypeDefinitionWeaver = new MixinsTypeDefinitionWeaver(_mixinsType, _mixinsMap);
            var typeDefinition = mixinsTypeDefinitionWeaver.Weave();

            _methodWeavers.ForEach(methodWeaver => {
                var methodBuilder = methodWeaver.DefineMethod();
                var ilGenerator = methodBuilder.GetILGenerator();

                methodWeaver.WeaveMethodScope(ilGenerator, typeDefinition);
                methodWeaver.WeaveEndMethod(ilGenerator);
            });
        }
    }
}
