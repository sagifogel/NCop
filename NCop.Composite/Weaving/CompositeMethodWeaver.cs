using NCop.Core.Extensions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Composite.Weaving
{
    internal class CompositeMethodWeaver : AbstractMethodWeaver
    {
        internal CompositeMethodWeaver(MethodInfo methodInfo, Type type, IMethodSignatureWeaver methodDefinitionWeaver, IEnumerable<IMethodWeaver> methodWeavers)
            : base(methodInfo, type) {
            MethodDefintionWeaver = methodDefinitionWeaver;
            MethodScopeWeaver = new MethodScopeWeaversQueue(methodWeavers.Select(weaver => weaver.MethodScopeWeaver));
            MethodEndWeaver = new MethodEndWeaver();
        }

        public override MethodBuilder DefineMethod(ITypeDefinition typeDefinition) {
            return MethodDefintionWeaver.Weave(MethodInfo, typeDefinition);
        }

        public override ILGenerator WeaveMethodScope(ILGenerator ilGenerator, ITypeDefinition typeDefinition) {
            return MethodScopeWeaver.Weave(ilGenerator, typeDefinition);
        }

        public override void WeaveEndMethod(ILGenerator ilGenerator) {
            MethodEndWeaver.Weave(MethodInfo, ilGenerator);
        }
    }
}
