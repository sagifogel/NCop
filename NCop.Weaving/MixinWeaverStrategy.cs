using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.Weaving
{
    public class MixinWeaverStrategy : ITypeWeaver
    {
        public MixinWeaverStrategy(ITypeDefinitionWeaver typeDefinitionWeaver, IEnumerable<IMethodWeaver> methodWeavers) {
            MethodWeavers = methodWeavers;
            TypeDefinitionWeaver = typeDefinitionWeaver;
        }

        public IEnumerable<IMethodWeaver> MethodWeavers { get; private set; }

        public ITypeDefinitionWeaver TypeDefinitionWeaver { get; private set; }

        public void Weave() {
            var typeDefinition = TypeDefinitionWeaver.Weave();

            MethodWeavers.ForEach(methodWeaver => {
                var methodBuilder = methodWeaver.DefineMethod();
                var ilGenerator = methodBuilder.GetILGenerator();

                methodWeaver.WeaveMethodScope(ilGenerator);
                methodWeaver.WeaveEndMethod(ilGenerator);
            });
        }
    }
}
