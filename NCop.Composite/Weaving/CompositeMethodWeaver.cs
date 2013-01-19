using NCop.Core.Extensions;
using NCop.Core.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Composite.Weaving
{
    public class CompositeMethodWeaver : AbstractMethodWeaver
    {
        public CompositeMethodWeaver(MethodInfo methodInfo, Type type, IMethodSignatureWeaver methodDefinitionWeaver, IEnumerable<IMethodWeaver> methodWeavers)
            : base(methodInfo, type) {
            MethodDefintionWeaver = methodDefinitionWeaver;
            MethodScopeWeaver = new MethodScopeWeaversQueue(methodWeavers.Select(weaver => weaver.MethodScopeWeaver));
            MethodEndWeaver = new MethodEndWeaver();
        }

        public override MethodBuilder DefineMethod() {
            return MethodDefintionWeaver.Weave(MethodInfo);
        }

        public override ILGenerator WeaveMethodScope(ILGenerator ilGenerator, ITypeDefinition typeDefinition) {
            return MethodScopeWeaver.Weave(ilGenerator, typeDefinition);
        }

        public override void WeaveEndMethod(ILGenerator ilGenerator) {
            MethodEndWeaver.Weave(MethodInfo, ilGenerator);
        }
    }
}
