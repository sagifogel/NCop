using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.Core.Weaving
{
    public class TypeWeaverStrategy : ITypeWeaver
    {
        public TypeWeaverStrategy(ITypeDefinitionWeaver typeDefinitionWeaver, IEnumerable<IMethodWeaver> methodWeavers) {
            MethodWeavers = methodWeavers;
            TypeDefinitionWeaver = typeDefinitionWeaver;
        }

        public void Weave() {
            var typeDefinition = TypeDefinitionWeaver.Weave();

            MethodWeavers.ForEach(methodWeaver => {
                var methodBuilder = methodWeaver.DefineMethod(typeDefinition.TypeBuilder);
                var ilGenerator = methodBuilder.GetILGenerator();

                methodWeaver.WeaveMethodScope(ilGenerator);
                methodWeaver.WeaveEndMethod(ilGenerator);
            });
        }

        public IEnumerable<IMethodWeaver> MethodWeavers { get; private set; }

        public ITypeDefinitionWeaver TypeDefinitionWeaver { get; private set; }
    }
}
